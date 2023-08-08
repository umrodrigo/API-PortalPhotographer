using Api.View;
using AutoMapper;
using Data;

namespace Api.ViewModel.Interface
{
    public interface IUserViewModel
    {
        IMapper Mapper { get; }
        PhotographerContext Context { get; }
        Task Insert(EntityUserView view);
        Task Update(EntityUserView view);
        Task<EntityUserView> GetById(Guid id);

    }
}
