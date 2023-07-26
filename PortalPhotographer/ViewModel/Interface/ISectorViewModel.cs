using Api.View;
using AutoMapper;
using Data;

namespace Api.ViewModel.Interface
{
    public interface ISectorViewModel
    {
        IMapper Mapper { get; }
        PhotographerContext Context { get; }
        Task Insert(EntitySectorView view);
        Task Update(EntitySectorView view);
        Task<List<EntitySectorView>> GetAll();
        Task<Task> Delete(EntitySectorView view);

    }
}
