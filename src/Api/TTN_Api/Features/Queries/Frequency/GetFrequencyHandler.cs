using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.Data;
using System.Collections.Generic;

namespace TTN_Tracker.Queries
{
    public class GetFrequencyHandler : IRequestHandler<GetFrequencyQuery, List<ComboListDto>>
    {
        private readonly IMediator _mediator;
        private ICommonQueries _qryRepo;

        public GetFrequencyHandler(IMediator mediator, ICommonQueries qryRepo)
        {
            _mediator = mediator;
            _qryRepo = qryRepo;

        }

        public async Task<List<ComboListDto>> Handle(GetFrequencyQuery request, CancellationToken cancellationToken)
        {
            var qryResponse = await _qryRepo.GetFrequencyList();

            return qryResponse; //_mapper.Map<AchOffsetAccountReadDto>(qryResponse);

        }
    }


}