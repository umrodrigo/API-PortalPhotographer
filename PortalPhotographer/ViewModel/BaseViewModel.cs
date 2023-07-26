using AutoMapper;
using Data;

namespace Financ.Api.ViewModel
{
    public class BaseViewModel
    {
        protected PhotographerContext _context;
        protected IMapper _mapper;
        public BaseViewModel(PhotographerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
