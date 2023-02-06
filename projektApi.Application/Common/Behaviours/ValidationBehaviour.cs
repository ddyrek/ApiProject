using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>
 : IPipelineBehavior<TRequest, TResponse>
 where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                //w metodzie select bedziemy wykonyawć validate na contextcie validacyjnym,
                //a nastepnie bedziemy z rezulatów takiej validacji pobierać tylko errory,
                //jezeli taki error nie bedzie pusty, to zwrócimy go do listy
                //jesli po takiej operacji ilość błędów bedzie różna od zera,
                //to bedziemy to logować (ValidationExceptions lub customwe Exceptions- lekcja 12 modul 6)
                var failures = _validators.Select(v => v.Validate(context)).SelectMany(result => result.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures); //w dokumentacj FluentValidation przykłady uzycia
                }
            }
            //na sam koniec zwracamy nasz Response, a w kontrolerze musimy zaimplementować metode HttpPost
            return await next();
        }
    }
}

