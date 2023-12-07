namespace ETAPP.WebUI.ViewModels;

public class IdResult<T> 
{
    public IdResult(T id)
    {
        Id = id;
    }
    
    public T Id { get; set; } 
}

public class IdResult : IdResult<int>
{
    public IdResult(int id) : base(id)
    {
        
    }
    
    public static IdResult<int> Ok(int id)
    {
        return new IdResult<int>(id);
    }
    
    public static IdResult<Guid> Ok(Guid id)
    {
        return new IdResult<Guid>(id);
    }
}