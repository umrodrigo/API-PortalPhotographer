using Api.View;
using AutoMapper;
using Data;

namespace Api.ViewModel.Interface
{
    public interface IPhotoViewModel
    {
        IMapper Mapper { get; }
        PhotographerContext Context { get; }
        Task Insert(EntityPhotoView view);
        Task InsertList(List<EntityPhotoView> view);
        Task Update(EntityPhotoView view);
        Task<List<EntityPhotoView>> GetAll();
        Task<Task> Delete(EntityPhotoView view);

    }
}
