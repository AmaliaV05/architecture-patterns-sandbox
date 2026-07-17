namespace ECommerceLite.BusinessLogic.Interfaces
{
    public interface IValidator<T>
    {
        public bool Validate(T entity);
    }
}
