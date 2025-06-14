﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AlbumManager>().As<IAlbumService>().SingleInstance();
            builder.RegisterType<EfAlbumDal>().As<IAlbumDal>().SingleInstance();

            builder.RegisterType<ArtistManager>().As<IArtistService>().SingleInstance();
            builder.RegisterType<EfArtistDal>().As<IArtistDal>().SingleInstance();

            builder.RegisterType<TrackManager>().As<ITrackService>().SingleInstance();
            builder.RegisterType<EfTrackDal>().As<ITrackDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
