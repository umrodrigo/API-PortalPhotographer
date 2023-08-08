using Api.View;
using Api.ViewModel.Interface;
using AutoMapper;
using Data;
using Data.Clients;
using Data.Models;
using Financ.Api.ViewModel;

namespace Api.ViewModel
{
    public class UserViewModel : BaseViewModel, IUserViewModel
    {
        public IMapper Mapper => _mapper;
        public PhotographerContext Context => _context;
        private readonly UserRep _Rep;
        public UserViewModel(PhotographerContext context, IMapper mapper)
            : base(context, mapper)
        {
            _Rep = new UserRep(_context);
        }

        public async Task Insert(EntityUserView view)
        {
            var model = _Rep.Save(_mapper.Map<EntityUser>(view));

            await _context.SaveChangesAsync();

            _mapper.Map(model, view);
        }

        public async Task Update(EntityUserView view)
        {
            var model = _Rep.Save(_mapper.Map<EntityUser>(view));

            await _context.SaveChangesAsync();

            _mapper.Map(model, view);
        }

        public async Task<EntityUserView> GetById(Guid id)
        {
            var result = await _Rep.GetById(id);

            return _mapper.Map<EntityUserView>(result);
        }
    }
}
