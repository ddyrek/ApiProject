using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Pipeline - wszystko co wykona się między Reqestem a Responsem, wykorzystują to Behaviours (midleware)

namespace projektApi.Application.Common.Behaviours
{
    //LoggingBehaviour - jest odpowiedzialny za logowanie (logi) przed wykonaniem request (queris i command)
    //IRequestPreProcessor<TRequest> - przed wykonaniem Pipelinea
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation("projektApi Request: {Name} {@Request}",
                requestName, request);
        }
    }
}
