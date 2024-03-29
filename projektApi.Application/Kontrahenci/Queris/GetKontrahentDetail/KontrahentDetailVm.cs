﻿using AutoMapper;
using projektApi.Application.Common.Mappings;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Koontrahenci.Queris.GetKontrahentDetail
{
    public class KontrahentDetailVm : IMapFrom<Kontrahent>
    {
        public int Id { get; set; }
        public string NazwaFirmy { get; set; }
        public string Ulica { get; set; }
        public string NumerBudynku { get; set; }
        public string NumerLokalu { get; set; }
        public string Nip { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public int StatusId { get; set; }
        public string InactivatedBy { get; set; }
        public DateTime Inactivated { get; set; }
        //public string LastKlientName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Kontrahent, KontrahentDetailVm>();
            //.ForMember(d => d.NazwaFirmy, map => map.MapFrom(src => src.NazwaFirmy.ToString()))
            //.ForMember(d => d.LastKlientName, map => map.MapFrom(src => src.Klienci.OrderByDescending(p => p.Name).FirstOrDefault().Name)); //gdy nie uzywamy  castomowego Resolvera
            //.ForMember(d => d.LastKlientName, map => map.MapFrom<LastKlientNameResolver>());
        }

        //private class LastKlientNameResolver : IValueResolver<Kontrahent, object, string>
        //{
        //    public string Resolve(Kontrahent source, object destination, string destMember, ResolutionContext context)
        //    {
        //        if (source.Klienci is not null && source.Klienci.Any())
        //        {
        //            var lastKlient = source.Klienci.OrderByDescending(p => p.KlientName).FirstOrDefault();
        //            return lastKlient.KlientName;
        //        }
        //        return string.Empty;
        //    }
        //}

    }
}
