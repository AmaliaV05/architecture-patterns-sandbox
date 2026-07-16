using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AdminTool.Configuration
{
    public class SqlConfigurationSource : IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder> _optionsAction;

        public SqlConfigurationSource(Action<DbContextOptionsBuilder> optionsAction)
        {
            _optionsAction = optionsAction;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SqlConfigurationProvider(_optionsAction);
        }
    }
}
