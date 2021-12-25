using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts.OrgChart;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.MVC.Mapper
{
    public static class TCMapper
    {
        private static readonly string GenericLookupOptionFieldPostFix = "_OptionName";

        static TCMapper()
        {
            #region Grup Mapping
            AutoMapper.Mapper.CreateMap<Users, AddUserRequest>().IgnoreAllNonExisting();
            AutoMapper.Mapper.CreateMap<AddUserRequest, Users>().IgnoreAllNonExisting();
            #endregion
            #region Grup Mapping
            AutoMapper.Mapper.CreateMap<UserProfile, AddUserRequest>().IgnoreAllNonExisting();
            AutoMapper.Mapper.CreateMap<AddUserRequest, UserProfile>().IgnoreAllNonExisting();
            #endregion

        }

        #region MappersMethods
        private static TDestination EncryptTFields<TDestination>(this TDestination vm)
            where TDestination : class
        {
            var properties = vm.GetType().GetProperties().ToList();
            var toBeEncryptedFields = properties.Where(w => w.Name.StartsWith("Encrypted_")).ToList();
            toBeEncryptedFields.Each(e =>
            {
                if (e.PropertyType != typeof(string))
                {
                    throw new Exception("Encrypted_" + e.Name + " type string olmalı.");
                }
                string nonEncryptedPropName = e.Name.Replace("Encrypted_", "");
                object nonEncryptedPropValue = properties.FirstOrDefault(f => f.Name == nonEncryptedPropName).GetValue(vm);
                if (nonEncryptedPropValue != null)
                {
                    string encryptedValue = QueryStringCrypto.Encrypt(nonEncryptedPropValue);
                    e.SetValue(vm, encryptedValue);
                }
            });
            return vm;
        }

        private static TDestination EncryptIEnumerableTFields<TDestination>(this TDestination vm)
            where TDestination : IEnumerable<object>
        {
            vm.Each(e =>
            {
                e.EncryptTFields();
            });
            return vm;
        }

        /// <summary>
        /// Model'den VM'e map
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static TDestination ConvertToVM<TDestination>(object from)
            where TDestination : class
        {
            return AutoMapper.Mapper.Map<TDestination>(from);
        }

        /// <summary>
        /// Model'den VM'e encrypted map
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static TDestination ConvertToEncryptedVM<TDestination>(object from)
            where TDestination : class
        {
            var result = ConvertToVM<TDestination>(from);
            return result.EncryptTFields();
        }

        /// <summary>
        /// Model listesinden VM listesine map
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static TDestination ConvertToVMList<TDestination>(IEnumerable<object> from)
            where TDestination : IEnumerable<object>
        {
            return AutoMapper.Mapper.Map<TDestination>(from);
        }

        /// <summary>
        /// Model listesinden VM listesine encrypted map
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static TDestination ConvertToEncryptedVMList<TDestination>(IEnumerable<object> from)
            where TDestination : IEnumerable<object>
        {
            var result = ConvertToVMList<TDestination>(from);
            return result.EncryptIEnumerableTFields();
        }

        /// <summary>
        /// Model'den varolan bir VM üzerine map
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static TDestination ConvertToVM<TSource, TDestination>(TSource from, TDestination to)
            where TSource : class
            where TDestination : class
        {
            if (to == null || to == default(TDestination))
                to = (TDestination)Activator.CreateInstance(typeof(TDestination));
            return AutoMapper.Mapper.Map<TSource, TDestination>(from, to);
        }

        /// <summary>
        /// Model'den varolan bir VM üzerine encrypted map
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static TDestination ConvertToEncryptedVM<TSource, TDestination>(TSource from, TDestination to)
            where TSource : class
            where TDestination : class
        {
            var result = ConvertToVM<TSource, TDestination>(from, to);
            return result.EncryptTFields();
        }

        /// <summary>
        /// VM'den Model'e map
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static TDestination ConvertToEntity<TDestination>(object from)
            where TDestination : class
        {
            return AutoMapper.Mapper.Map<TDestination>(from);
        }

        /// <summary>
        /// VM listesinden Model listesine map
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static TDestination ConvertToEntityList<TDestination>(IEnumerable<object> from)
            where TDestination : IEnumerable<object>
        {
            return AutoMapper.Mapper.Map<TDestination>(from);
        }

        /// <summary>
        /// VM'den varolan bir Model üzerine map
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static TDestination ConvertToEntity<TSource, TDestination>(TSource from, TDestination to)
            where TSource : class
            where TDestination : class
        {
            if (to == null || to == default(TDestination))
                to = (TDestination)Activator.CreateInstance(typeof(TDestination));
            return AutoMapper.Mapper.Map<TSource, TDestination>(from, to);
        }

        public static TDestination ConvertToOther<TDestination>(object from)
          where TDestination : class
        {
            return AutoMapper.Mapper.Map<TDestination>(from);
        }

        internal static TDestination ConvertTo<TDestination>(object from)
            where TDestination : class
        {
            return AutoMapper.Mapper.Map<TDestination>(from);
        }
        #endregion
    }
}