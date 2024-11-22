namespace CleanArchMvc.Application.Mappings
{
    public class AutoMapperConfiguration
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                typeof(DomainToDTOMappingProfile)
            };
        }
    }
}
