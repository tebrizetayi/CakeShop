using AutoMapper;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using CakeShop.Net.Model.VM;
using System;
using System.Collections.Generic;

namespace CakeShop.Net.Model
{
    /// <summary>
    /// Transformation from Domain model to Data Transfer object and vice versa.
    /// Transformation from View model to Data Transfer object and vice versa.
    /// </summary>
    public static class Transformation
    {
        /// <summary>
        /// Initalizing mapper.Should be used in every application that uses Data Transfer Object ,
        /// Domain Model and View Model.
        /// </summary>
        public static void MapperInitialization()
        {
            Mapper.Initialize(cfg =>
            {
                #region User Transformations
                cfg.CreateMap<User, UserDto>().ForMember(s => s.AlternatePassword, m => m.MapFrom(p => p.UserAlternatePassword))
                                              .ForMember(s => s.CreatedDate, m => m.MapFrom(p => p.UserCreatedDate))
                                              .ForMember(s => s.Email, m => m.MapFrom(p => p.UserEmail))
                                              .ForMember(s => s.FirstName, m => m.MapFrom(p => p.UserFirstName))
                                              .ForMember(s => s.Id, m => m.MapFrom(p => p.Id))
                                              .ForMember(s => s.LastName, m => m.MapFrom(p => p.UserLastName))
                                              .ForMember(s => s.ModifiedDate, m => m.MapFrom(p => p.UserModifiedDate))
                                              .ForMember(s => s.Password, m => m.MapFrom(p => p.UserPassword))
                                              .ForMember(s => s.Status, m => m.MapFrom(p => p.UserStatus))
                                              .ForMember(s => s.Username, m => m.MapFrom(p => p.UserUsername));

                cfg.CreateMap<UserDto, User>().ForMember(s => s.UserAlternatePassword, m => m.MapFrom(p => p.AlternatePassword))
                                              .ForMember(s => s.UserCreatedDate, m => m.MapFrom(p => p.CreatedDate))
                                              .ForMember(s => s.UserEmail, m => m.MapFrom(p => p.Email))
                                              .ForMember(s => s.UserFirstName, m => m.MapFrom(p => p.FirstName))
                                              .ForMember(s => s.Id, m => m.MapFrom(p => p.Id))
                                              .ForMember(s => s.UserLastName, m => m.MapFrom(p => p.LastName))
                                              .ForMember(s => s.UserModifiedDate, m => m.MapFrom(p => p.ModifiedDate))
                                              .ForMember(s => s.UserPassword, m => m.MapFrom(p => p.Password))
                                              .ForMember(s => s.UserStatus, m => m.MapFrom(p => p.Status))
                                              .ForMember(s => s.UserUsername, m => m.MapFrom(p => p.Username));

                cfg.CreateMap<UserDto, UserVM>().ForMember(s => s.Email, m => m.MapFrom(p => p.Email))
                                                  .ForMember(s => s.FirstName, m => m.MapFrom(p => p.FirstName))
                                                  .ForMember(s => s.Id, m => m.MapFrom(p => p.Id))
                                                  .ForMember(s => s.LastName, m => m.MapFrom(p => p.LastName))
                                                  .ForMember(s => s.Username, m => m.MapFrom(p => p.Username));


                #endregion

                #region Pie Transformations
                cfg.CreateMap<Pie, PieDto>().ForMember(s => s.AllergyInformation, m => m.MapFrom(p => p.PieAllergyInformation))
                                              .ForMember(s => s.CreatedDate, m => m.MapFrom(p => p.PieCreatedDate))
                                              .ForMember(s => s.Id, m => m.MapFrom(p => p.Id))
                                              .ForMember(s => s.ImageThumbnailUrl, m => m.MapFrom(p => p.PieImageThumbnailUrl))
                                              .ForMember(s => s.ImageUrl, m => m.MapFrom(p => p.PieImageUrl))
                                              .ForMember(s => s.InStock, m => m.MapFrom(p => p.PieInStock))
                                              .ForMember(s => s.ModifiedDate, m => m.MapFrom(p => p.PieModifiedDate))
                                              .ForMember(s => s.IsPieOfTheWeek, m => m.MapFrom(p => p.PieIsPieOfTheWeek))
                                              .ForMember(s => s.Status, m => m.MapFrom(p => p.PieStatus))
                                              .ForMember(s => s.LongDescription, m => m.MapFrom(p => p.PieLongDescription))
                                              .ForMember(s => s.Name, m => m.MapFrom(p => p.PieName))
                                              .ForMember(s => s.Price, m => m.MapFrom(p => p.PiePrice))
                                              .ForMember(s => s.ShortDescription, m => m.MapFrom(p => p.PieShortDescription));

                cfg.CreateMap<PieDto, Pie>().ForMember(s => s.PieAllergyInformation, m => m.MapFrom(p => p.AllergyInformation))
                                              .ForMember(s => s.PieCreatedDate, m => m.MapFrom(p => p.CreatedDate))
                                              .ForMember(s => s.Id, m => m.MapFrom(p => p.Id))
                                              .ForMember(s => s.PieImageThumbnailUrl, m => m.MapFrom(p => p.ImageThumbnailUrl))
                                              .ForMember(s => s.PieImageUrl, m => m.MapFrom(p => p.ImageUrl))
                                              .ForMember(s => s.PieInStock, m => m.MapFrom(p => p.InStock))
                                              .ForMember(s => s.PieModifiedDate, m => m.MapFrom(p => p.ModifiedDate))
                                              .ForMember(s => s.PieIsPieOfTheWeek, m => m.MapFrom(p => p.IsPieOfTheWeek))
                                              .ForMember(s => s.PieStatus, m => m.MapFrom(p => p.Status))
                                              .ForMember(s => s.PieLongDescription, m => m.MapFrom(p => p.LongDescription))
                                              .ForMember(s => s.PieName, m => m.MapFrom(p => p.Name))
                                              .ForMember(s => s.PiePrice, m => m.MapFrom(p => p.Price))
                                              .ForMember(s => s.PieShortDescription, m => m.MapFrom(p => p.ShortDescription));
                #endregion

                #region ShoppingCartItem
                cfg.CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ForMember(s => s.Amount, m => m.MapFrom(p => p.ShoppingCartItemAmount))
                              .ForMember(s => s.CreatedDate, m => m.MapFrom(p => p.ShoppingCartItemCreatedDate))
                              .ForMember(s => s.Id, m => m.MapFrom(p => p.Id))
                              .ForMember(s => s.ModifiedDate, m => m.MapFrom(p => p.ShoppingCartItemModifiedDate))
                              .ForMember(s => s.Pie, m => m.MapFrom(p => new PieDto() { Id=p.ShoppingCartItem_PieId}))
                              .ForMember(s => s.ShoppingCart, m => m.MapFrom(p => new PieDto() { Id = p.ShoppingCartItem_ShoppingCartId }));
                cfg.CreateMap<ShoppingCartItemDto, ShoppingCartItem>().ForMember(s => s.ShoppingCartItemAmount, m => m.MapFrom(p => p.Amount))
                              .ForMember(s => s.ShoppingCartItemCreatedDate, m => m.MapFrom(p => p.CreatedDate))
                              .ForMember(s => s.Id, m => m.MapFrom(p => p.Id))
                              .ForMember(s => s.ShoppingCartItemModifiedDate, m => m.MapFrom(p => p.ModifiedDate))
                              .ForMember(s => s.ShoppingCartItem_PieId, m => m.MapFrom(p => p.Pie!=null?p.Pie.Id:Guid.Empty))
                              .ForMember(s => s.ShoppingCartItemStatus, m => m.MapFrom(p => p.Status))
                              .ForMember(s => s.ShoppingCartItem_ShoppingCartId, m => m.MapFrom(p => p.ShoppingCart != null ? p.ShoppingCart.Id : Guid.Empty));
                cfg.CreateMap<ShoppingCartItemDto, ShoppingCartItemVM>().ForMember(s => s.Amount, m => m.MapFrom(p => p.Amount))
                                                                        .ForMember(s => s.PieId, m => m.MapFrom(p => p.Pie.Id));


                #endregion

                #region Order
                cfg.CreateMap<OrderVM, OrderDto>().ForMember(s => s.AddressLine1, m => m.MapFrom(p => p.AddressLine1))
                                                  .ForMember(s => s.AddressLine2, m => m.MapFrom(p => p.AddressLine2))
                                                  .ForMember(s => s.City, m => m.MapFrom(p => p.City))
                                                  .ForMember(s => s.Country, m => m.MapFrom(p => p.Country))
                                                  .ForMember(s => s.Email, m => m.MapFrom(p => p.Email))
                                                  .ForMember(s => s.FirstName, m => m.MapFrom(p => p.FirstName))
                                                  .ForMember(s => s.LastName, m => m.MapFrom(p => p.LastName))
                                                  .ForMember(s => s.PhoneNumber, m => m.MapFrom(p => p.PhoneNumber))
                                                  .ForMember(s => s.State, m => m.MapFrom(p => p.State))
                                                  .ForMember(s => s.Total, m => m.MapFrom(p => p.OrderTotal))
                                                  .ForMember(s => s.ZipCode, m => m.MapFrom(p => p.ZipCode));

                cfg.CreateMap<OrderDto, Order>().ForMember(s => s.OrderAddressLine1, m => m.MapFrom(p => p.AddressLine1))
                                                  .ForMember(s => s.OrderAddressLine2, m => m.MapFrom(p => p.AddressLine2))
                                                  .ForMember(s => s.OrderCity, m => m.MapFrom(p => p.City))
                                                  .ForMember(s => s.OrderCountry, m => m.MapFrom(p => p.Country))
                                                  .ForMember(s => s.OrderEmail, m => m.MapFrom(p => p.Email))
                                                  .ForMember(s => s.OrderFirstName, m => m.MapFrom(p => p.FirstName))
                                                  .ForMember(s => s.OrderLastName, m => m.MapFrom(p => p.LastName))
                                                  .ForMember(s => s.OrderPhoneNumber, m => m.MapFrom(p => p.PhoneNumber))
                                                  .ForMember(s => s.OrderState, m => m.MapFrom(p => p.State))
                                                  .ForMember(s => s.OrderStatus, m => m.MapFrom(p => p.Status))
                                                  .ForMember(s => s.OrderZipCode, m => m.MapFrom(p => p.ZipCode))
                                                  .ForMember(s => s.OrderModifiedDate, m => m.MapFrom(p => p.ModifiedDate))
                                                  .ForMember(s => s.OrderCreatedDate, m => m.MapFrom(p => p.CreatedDate));
                #endregion

                #region OrderDetail
                cfg.CreateMap<OrderDetailDto, OrderDetail>().ForMember(s => s.Id, m => m.MapFrom(p => p.Id))
                                                  .ForMember(s => s.OrderDetailCreatedDate, m => m.MapFrom(p => p.CreatedDate))
                                                  .ForMember(s => s.OrderDetailModifiedDate, m => m.MapFrom(p => p.ModifiedDate))
                                                  .ForMember(s => s.OrderDetailAmount, m => m.MapFrom(p => p.Amount))
                                                  .ForMember(s => s.OrderDetailPrice, m => m.MapFrom(p => p.Price))
                                                  .ForMember(s => s.OrderDetailStatus, m => m.MapFrom(p => p.Status))
                                                  .ForMember(s => s.OrderDetail_OrderId, m => m.MapFrom(p => p.Order!=null?p.Order.Id :Guid.Empty))
                                                  .ForMember(s => s.OrderDetail_PieId, m => m.MapFrom(p => p.Order!=null?p.Pie.Id:Guid.Empty));

                cfg.CreateMap<OrderDetail, OrderDetailDto>().ForMember(s => s.Id, m => m.MapFrom(p => p.Id))
                                                  .ForMember(s => s.ModifiedDate, m => m.MapFrom(p => p.OrderDetailModifiedDate))
                                                  .ForMember(s => s.Order, m => m.MapFrom(p => new OrderDto() { Id = p.OrderDetail_OrderId }))
                                                  .ForMember(s => s.Pie, m => m.MapFrom(p => new PieDto() { Id = p.OrderDetail_PieId }))
                                                  .ForMember(s => s.Price, m => m.MapFrom(p => p.OrderDetailPrice))
                                                  .ForMember(s => s.Status, m => m.MapFrom(p => p.OrderDetailStatus))
                                                  .ForMember(s => s.Amount, m => m.MapFrom(p => p.OrderDetailAmount))
                                                  .ForMember(s => s.CreatedDate, m => m.MapFrom(p => p.OrderDetailCreatedDate));
                #endregion

            });
        }

        /// <summary>
        /// Function converts object from Source type to Destination type.
        /// </summary>
        /// <typeparam name="Source">Source type of the object.</typeparam>
        /// <typeparam name="Dest">Destination type of the object.</typeparam>
        /// <param name="s">The object that should be transformed.</param>
        /// <returns></returns>
        public static Dest Convert<Source, Dest>(Source s)
        {
            return Mapper.Map<Source, Dest>(s);
        }

        /// <summary>
        /// Function converts list of object from Source type to Destination type. 
        /// </summary>
        /// <typeparam name="Source">Source type of the object.</typeparam>
        /// <typeparam name="Dest">Destination type of the object.</typeparam>
        /// <param name="lstSource">The list of objects that should be transformed.</param>
        /// <returns></returns>
        public static IEnumerable<Dest> Convert<Source, Dest>(IEnumerable<Source> lstSource)
        {
            if (lstSource == null)
                return null;

            List<Dest> lstDest = new List<Dest>();
            foreach (var itemS in lstSource)
            {
                Dest itemDest = Convert<Source, Dest>(itemS);
                lstDest.Add(itemDest);
            }
            return lstDest;
        }

        /// <summary>
        /// Resets the Mapper. Mainly used in Units.
        /// </summary>
        public static void MapperReset()
        {
            Mapper.Reset();
        }
}
}
