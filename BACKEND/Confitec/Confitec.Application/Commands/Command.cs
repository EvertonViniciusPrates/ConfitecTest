using Confitec.Domain.Results;
using MediatR;

namespace Confitec.Application.Commands
{
    public class Command : IRequest<BaseResult>, IBaseRequest
    {
        public string Type
        {

            get
            {
                return this.GetType().Name;
            }

        }
    }
}
