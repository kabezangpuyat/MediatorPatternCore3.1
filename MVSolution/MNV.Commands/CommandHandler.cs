using AutoMapper;
using MNV.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNV.Commands
{
    public abstract class CommandHandler
    {
        protected readonly IDataContext _dataContext;
        protected readonly IMapper _mapper;
        public CommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
    }
}
