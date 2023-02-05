using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Common.Behaviours
{
    // PerformanceBehaviour - to zachowanie które trwa cały czas Pipelineu czyli od Reqestu do Responsu
    //pomaga monitorować po przez logi wydajność aplikacji na naszych zasobach sprzetowych
    //ma on za zadanie policzyć jak długo wykonywany jest Reqest,
    //jeżeli bedzie wykonywany dłuzej niż ustawiony czas, taka informacja zostanie zalogowana
    //IPipelineBehavior  działa na całej długości Requestu
    public class PerformanceBehaviour<TRequest, TResponse>
: IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger;
        private readonly Stopwatch _timer;
        public PerformanceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsed = _timer.ElapsedMilliseconds; //przeliczenie ile czasu mineło

            if (elapsed > 500)
            {
                var requestName = typeof(TRequest).Name;

                _logger.LogInformation("Projekt Api Long Running Request: {Name} ({elapsed} milliseconds) {@Request}",
                    requestName, elapsed, request);
            }

            return response;
        }
    }
}
