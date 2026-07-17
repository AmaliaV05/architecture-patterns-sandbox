using CsvHelper;
using DataHeavyTool.BusinessLogic.Helpers;
using DataHeavyTool.BusinessLogic.Interfaces;
using DataHeavyTool.Data.Constants;
using DataHeavyTool.Data.Data;
using DataHeavyTool.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;

namespace DataHeavyTool.BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private readonly DataHeavyToolDbContext _context;

        public FileService(DataHeavyToolDbContext context)
        {
            _context = context;
        }

        public async Task ProcessLargeCsvAsync(IFormFile file)
        {
            DataTable table = new();

            table.Columns.Add(TransactionColumns.UserGuid, typeof(Guid));
            table.Columns.Add(TransactionColumns.AssetTicker, typeof(string));
            table.Columns.Add(TransactionColumns.TransactionType, typeof(string));
            table.Columns.Add(TransactionColumns.Quantity, typeof(decimal));
            table.Columns.Add(TransactionColumns.PricePerUnit, typeof(decimal));
            table.Columns.Add(TransactionColumns.TransactionDate, typeof(DateTimeOffset));
            table.Columns.Add(TransactionColumns.Fee, typeof(decimal));

            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<TransactionMap>();
            var records = csv.GetRecordsAsync<Transaction>();

            await foreach (var record in records)
            {
                DataRow row = table.NewRow();

                row[TransactionColumns.UserGuid] = record.UserGuid;
                row[TransactionColumns.AssetTicker] = record.AssetTicker;
                row[TransactionColumns.TransactionType] = record.TransactionType;
                row[TransactionColumns.Quantity] = record.Quantity;
                row[TransactionColumns.PricePerUnit] = record.PricePerUnit;
                row[TransactionColumns.TransactionDate] = record.TransactionDate;
                row[TransactionColumns.Fee] = record.Fee;

                table.Rows.Add(row);

                if (table.Rows.Count >= 10000)
                {
                    await ExecuteBulkCopy(table);
                    table.Rows.Clear();
                }
            }

            if (table.Rows.Count > 0)
            {
                await ExecuteBulkCopy(table);
            }
        }

        private async Task ExecuteBulkCopy(DataTable table)
        {
            if (_context.Database.GetDbConnection() is not SqlConnection connection)
            {
                throw new InvalidOperationException("Conexiunea bazei de date nu este de tip SQL Server.");
            }

            bool wasClosed = connection.State == ConnectionState.Closed;
            if (wasClosed) await connection.OpenAsync();

            try
            {
                using var bulkCopy = new SqlBulkCopy(connection);
                bulkCopy.DestinationTableName = TableNames.Transactions;

                bulkCopy.ColumnMappings.Add(TransactionColumns.UserGuid, TransactionColumns.UserGuid);
                bulkCopy.ColumnMappings.Add(TransactionColumns.AssetTicker, TransactionColumns.AssetTicker);
                bulkCopy.ColumnMappings.Add(TransactionColumns.TransactionType, TransactionColumns.TransactionType);
                bulkCopy.ColumnMappings.Add(TransactionColumns.Quantity, TransactionColumns.Quantity);
                bulkCopy.ColumnMappings.Add(TransactionColumns.PricePerUnit, TransactionColumns.PricePerUnit);
                bulkCopy.ColumnMappings.Add(TransactionColumns.TransactionDate, TransactionColumns.TransactionDate);
                bulkCopy.ColumnMappings.Add(TransactionColumns.Fee, TransactionColumns.Fee);

                await bulkCopy.WriteToServerAsync(table);
            }
            finally
            {
                if (wasClosed) await connection.CloseAsync();
            }
        }
    }
}
