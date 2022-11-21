using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utitlities.Helpers.FileHelper;
using Core.Utitlities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public  class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<TrainerManager>().As<ITrainerService>().SingleInstance();
            builder.RegisterType<EfTrainerDal>().As<ITrainerDal>().SingleInstance();
            builder.RegisterType<TrainerImageManager>().As<ITrainerImageService>().SingleInstance();
            builder.RegisterType<EfTrainerImageDal>().As<ITrainerImageDal>().SingleInstance();
            builder.RegisterType<SportEduManager>().As<ISportEduService>().SingleInstance();
            builder.RegisterType<EfSportEduDal>().As<ISportEduDal>().SingleInstance();
            builder.RegisterType<PerDevEduManager>().As<IPerDevEduService>().SingleInstance();
            builder.RegisterType<EfPerDevEduDal>().As<IPerDevEduDal>().SingleInstance();
            builder.RegisterType<HSchoolManager>().As<IHSchoolEduService>().SingleInstance();
            builder.RegisterType<EfHSchoolEduDal>().As<IHSchoolEduDal>().SingleInstance();
            builder.RegisterType<FormOfEduManager>().As<IFormOfEduService>().SingleInstance();
            builder.RegisterType<EfFormOfEduDal>().As<IFormOfEduDal>().SingleInstance();
            builder.RegisterType<EducationManager>().As<IEducationService>().SingleInstance();
            builder.RegisterType<EfEducationDal>().As<IEducationDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>().SingleInstance();
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            builder.RegisterType<UserImageManager>().As<IUserImageService>().SingleInstance();
            builder.RegisterType<EfUserImageDal>().As<IUserImageDal>().SingleInstance();

            builder.RegisterType<TrainerOperationClaimManager>().As<ITrainerOperationClaimService>().SingleInstance();
            builder.RegisterType<EfTrainerOperationClaimDal>().As<ITrainerOperationClaimDal>().SingleInstance();

            builder.RegisterType<EfUserOperaitonClaimDal>().As<IUserOperationClaimDal>().SingleInstance();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimsService>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<PaymentManager>().As<IPaymentService>();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>();

            builder.RegisterType<CreditCardManager>().As<ICreditCardService>();
            builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
