namespace Lab1.Services;


public class ObjectMapperService<TSource,TDest>where TDest: new()
{
     TSource source;
     TDest dest;

     public TDest Map(TSource source)
     {
          if(source == null) throw new ArgumentNullException($"Source is null {nameof(source)}");
          var destProperties = typeof(TDest).GetProperties();
          var sourceProperties = typeof(TSource).GetProperties();
          TDest dest = new TDest();
          foreach (var VARIABLE in destProperties)
          {
               var sourceProperty = sourceProperties.FirstOrDefault(x =>
                    x.Name == VARIABLE.Name && x.PropertyType == VARIABLE.PropertyType
               );
               if (sourceProperty != null)
               {
                    VARIABLE.SetValue(dest, sourceProperty.GetValue(source));
                    
               }
          }
          return dest;
          }

     
}