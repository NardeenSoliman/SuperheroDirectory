namespace SuperheroDirectory.Application.Mappers.Base
{
    public interface IModelMapper<TModel,TDto>
    {
        public TDto Map(TModel model);
        public List<TDto> MapList(List<TModel> models);
    }
}
