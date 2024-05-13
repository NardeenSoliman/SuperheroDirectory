namespace SuperheroDirectory.Application.Mappers.Base
{
    public interface IDtoMapper<TModel, TDto>
    {
        public TModel Map(TDto dto);
        public List<TModel> MapList(List<TDto> dtos);
    }
}
