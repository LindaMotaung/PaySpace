namespace PaySpace.BusinessLogic.Mappers
{
    public interface IMapperBase
    {
        T2 Map<T1, T2>(T1 source, T2 destination);
        T2 Map<T1, T2>(T1 source);
        T1 Map<T1>(object source);
    }
}
