export interface PagedResult<T> {
  data: T[];
  totalCount: number;
  totalPages: number;
  pageSize: number;
  currentPage: number;
}