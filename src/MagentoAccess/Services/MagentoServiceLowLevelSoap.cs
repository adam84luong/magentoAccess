﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MagentoAccess.MagentoSoapServiceReference;
using MagentoAccess.Misc;

namespace MagentoAccess.Services
{
	internal class MagentoServiceLowLevelSoap : IMagentoServiceLowLevelSoap
	{
		public string ApiUser { get; private set; }

		public string ApiKey { get; private set; }

		public string Store { get; private set; }

		protected const string SoapApiUrl = "index.php/api/v2_soap/index/";

		protected readonly Mage_Api_Model_Server_Wsi_HandlerPortTypeClient _magentoSoapService;

		protected string _sessionId;

		protected DateTime _sessionIdCreatedAt;

		protected const int SessionIdLifeTime = 3590;

		private void LogTraceGetResponseException( Exception exception )
		{
			MagentoLogger.Log().Trace( exception, "[magento] SOAP throw an exception." );
		}

		internal async Task< string > GetSessionId( bool throwException = true )
		{
			try
			{
				if( !string.IsNullOrWhiteSpace( this._sessionId ) && DateTime.UtcNow.Subtract( this._sessionIdCreatedAt ).TotalSeconds < SessionIdLifeTime )
					return this._sessionId;
				loginResponse getSessionIdTask;

				getSessionIdTask = await this._magentoSoapService.loginAsync(this.ApiUser, this.ApiKey).ConfigureAwait(false);
				this._sessionIdCreatedAt = DateTime.UtcNow;
				return this._sessionId = getSessionIdTask.result;


				//var res = this._magentoSoapService.login( this.ApiUser, this.ApiKey );
				//return res;

			}
			catch( Exception exc )
			{
				if( throwException )
					throw new MagentoSoapException( string.Format( "An error occured during GetSessionId()" ), exc );
				else
				{
					this.LogTraceGetResponseException( exc );
					return null;
				}
			}
		}

		public MagentoServiceLowLevelSoap( string apiUser, string apiKey, string baseMagentoUrl, string store )
		{
			//this.ApiUser = apiUser;
			//this.ApiKey = apiKey;
			//this.Store = store;
			//var endPoint = new List< string > { baseMagentoUrl, SoapApiUrl }.BuildUrl();

			//var customBinding = new CustomBinding
			//{
			//	ReceiveTimeout = new TimeSpan( 0, 2, 30, 0 ),
			//	SendTimeout = new TimeSpan( 0, 2, 30, 0 ),
			//	OpenTimeout = new TimeSpan( 0, 2, 30, 0 ),
			//	CloseTimeout = new TimeSpan( 0, 2, 30, 0 ),
			//	Name = "CustomHttpBinding",
			//};

			var textMessageEncodingBindingElement = new TextMessageEncodingBindingElement
			{
				MessageVersion = MessageVersion.Soap11,
				WriteEncoding = new UTF8Encoding()
			};
			
			//var httpTransportBindingElement = new HttpTransportBindingElement
			//{
			//	DecompressionEnabled = false,
			//	MaxReceivedMessageSize = 999999999,
			//	MaxBufferSize = 999999999,
			//	MaxBufferPoolSize = 999999999,
			//	KeepAliveEnabled = true,
			//	AllowCookies = false
			//};

			//customBinding.Elements.Add(textMessageEncodingBindingElement);
			//customBinding.Elements.Add( httpTransportBindingElement );

			//this._magentoSoapService = new Mage_Api_Model_Server_Wsi_HandlerPortTypeClient( customBinding, new EndpointAddress( endPoint ) );

			//this._magentoSoapService.Endpoint.Behaviors.Add(new CustomBehavior());

			////////////////////////////////////////////////
			
			this.ApiUser = apiUser;
			this.ApiKey = apiKey;
			this.Store = store;
			var endPoint = new List<string> { baseMagentoUrl, SoapApiUrl }.BuildUrl();
			
			var httpTransportBindingElement = new HttpTransportBindingElement
			{
				DecompressionEnabled = false,
				MaxReceivedMessageSize = 999999999,
				MaxBufferSize = 999999999,
				MaxBufferPoolSize = 999999999,
				KeepAliveEnabled = true,
				AllowCookies = false
			};

			var customTextMessageBindingElement = new CustomTextMessageBindingElement()
			{
				MessageVersion = MessageVersion.Soap12WSAddressing10
			};

			var myTextMessageEncodingBindingElement = new MyTextMessageEncodingBindingElement(textMessageEncodingBindingElement,"qwe")
			{
				MessageVersion = MessageVersion.Soap11,
			};

			ICollection<BindingElement> bindingElements = new List<BindingElement>();
			HttpTransportBindingElement httpBindingElement = httpTransportBindingElement;
			var textBindingElement = myTextMessageEncodingBindingElement;
			bindingElements.Add(textBindingElement);
			bindingElements.Add(httpBindingElement);

			CustomBinding customBinding = new CustomBinding(bindingElements);
			customBinding.ReceiveTimeout = new TimeSpan( 0, 2, 30, 0 );
			customBinding.SendTimeout = new TimeSpan( 0, 2, 30, 0 );
			customBinding.OpenTimeout = new TimeSpan( 0, 2, 30, 0 );
			customBinding.CloseTimeout = new TimeSpan( 0, 2, 30, 0 );
			customBinding.Name = "CustomHttpBinding";

			this._magentoSoapService = new Mage_Api_Model_Server_Wsi_HandlerPortTypeClient(customBinding, new EndpointAddress(endPoint));

			this._magentoSoapService.Endpoint.Behaviors.Add(new CustomBehavior());

			//ICollection<BindingElement> bindingElements = new List<BindingElement>();
			//HttpTransportBindingElement httpBindingElement = new HttpTransportBindingElement();
			//CustomTextMessageBindingElement textBindingElement = new CustomTextMessageBindingElement();
			//bindingElements.Add(textBindingElement);
			//bindingElements.Add(httpBindingElement);
			//CustomBinding binding = new CustomBinding(bindingElements);


		}

		public virtual async Task< salesOrderListResponse > GetOrdersAsync( DateTime modifiedFrom, DateTime modifiedTo )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				filters filters;

				if( string.IsNullOrWhiteSpace( this.Store ) )
					filters = new filters { complex_filter = new complexFilter[ 2 ] };
				else
				{
					filters = new filters { complex_filter = new complexFilter[ 3 ] };
					filters.complex_filter[ 2 ] = new complexFilter() { key = "store_id", value = new associativeEntity() { key = "in", value = this.Store } };
				}

				filters.complex_filter[ 1 ] = new complexFilter() { key = "updated_at", value = new associativeEntity() { key = "from", value = modifiedFrom.ToSoapParameterString() } };
				filters.complex_filter[ 0 ] = new complexFilter() { key = "updated_at", value = new associativeEntity() { key = "to", value = modifiedTo.ToSoapParameterString() } };

				var res = await this._magentoSoapService.salesOrderListAsync( sessionId, filters ).ConfigureAwait( false );

				//crutch for magento 1.7 
				res.result = res.result.Where( x => x.updated_at.ToDateTimeOrDefault() >= modifiedFrom && x.updated_at.ToDateTimeOrDefault() <= modifiedTo ).ToArray();

				return res;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetOrdersAsync(modifiedFrom:{0},modifiedTo{1})", modifiedFrom, modifiedTo ), exc );
			}
		}

		public virtual async Task< salesOrderListResponse > GetOrdersAsync( IEnumerable< string > ordersIds )
		{
			var ordersIdsAgregated = string.Empty;
			try
			{
				ordersIdsAgregated = ordersIds.Aggregate( ( ac, x ) => ac += "," + x );

				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				filters filters;
				if( string.IsNullOrWhiteSpace( this.Store ) )
					filters = new filters { complex_filter = new complexFilter[ 1 ] };
				else
				{
					filters = new filters { complex_filter = new complexFilter[ 2 ] };
					filters.complex_filter[ 1 ] = new complexFilter() { key = "store_id", value = new associativeEntity() { key = "in", value = this.Store } };
				}

				filters.complex_filter[ 0 ] = new complexFilter() { key = "increment_id", value = new associativeEntity() { key = "in", value = ordersIdsAgregated } };

				var res = await this._magentoSoapService.salesOrderListAsync( sessionId, filters ).ConfigureAwait( false );

				return res;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetOrdersAsync({0})", ordersIdsAgregated ), exc );
			}
		}

		public virtual async Task< catalogProductListResponse > GetProductsAsync()
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var filters = new filters { filter = new associativeEntity[ 0 ] };

				var store = string.IsNullOrWhiteSpace( this.Store ) ? null : this.Store;

				var res = await this._magentoSoapService.catalogProductListAsync( sessionId, filters, store ).ConfigureAwait( false );

				return res;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetProductsAsync()" ), exc );
			}
		}

		public virtual async Task< catalogInventoryStockItemListResponse > GetStockItemsAsync( List< string > skusOrIds )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var skusArray = skusOrIds.ToArray();

				var res = await this._magentoSoapService.catalogInventoryStockItemListAsync( sessionId, skusArray ).ConfigureAwait( false );

				return res;
			}
			catch( Exception exc )
			{
				var productsBriefInfo = string.Join( "|", skusOrIds );
				throw new MagentoSoapException( string.Format( "An error occured during GetStockItemsAsync({0})", productsBriefInfo ), exc );
			}
		}

		public virtual async Task< bool > PutStockItemsAsync( List< PutStockItem > stockItems, string markForLog = "" )
		{
			try
			{
				const string currentMenthodName = "PutStockItemsAsync";
				var jsonSoapInfo = this.ToJsonSoapInfo();
				var productsBriefInfo = stockItems.ToJson();

				stockItems.ForEach(x =>
				{
					if (x.UpdateEntity.qty.ToDecimalOrDefault() > 0)
					{
						x.UpdateEntity.is_in_stock = 1;
						x.UpdateEntity.is_in_stockSpecified = true;
					}
					else
					{
						x.UpdateEntity.is_in_stock = 0;
						x.UpdateEntity.is_in_stockSpecified = false;
					}
				});

				MagentoLogger.LogTraceStarted( string.Format( "{{MethodName:{0}, Called From:{1}, SoapInfo:{2}, MethodParameters:{3}}}", currentMenthodName, markForLog, jsonSoapInfo, productsBriefInfo ) );

				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var res = await this._magentoSoapService.catalogInventoryStockItemMultiUpdateAsync( sessionId, stockItems.Select( x => x.Id ).ToArray(), stockItems.Select( x => x.UpdateEntity ).ToArray() ).ConfigureAwait( false );

				var result = res.result;

				var updateBriefInfo = string.Format( "{{Success:{0}}}", result );
				MagentoLogger.LogTraceEnded( string.Format( "{{MethodName:{0}, Called From:{1}, SoapInfo:{2}, MethodParameters:{3}, MethodResult:{4}}}", currentMenthodName, markForLog, jsonSoapInfo, productsBriefInfo, updateBriefInfo ) );

				return result;
			}
			catch( Exception exc )
			{
				var productsBriefInfo = string.Join( "|", stockItems.Select( x => string.Format( "Id:{0}, Qty:{1}", x.Id, x.UpdateEntity.qty ) ) );
				throw new MagentoSoapException( string.Format( "An error occured during PutStockItemsAsync({0})", productsBriefInfo ), exc );
			}
		}

		public virtual async Task<salesOrderInfoResponse> GetOrderAsync(string incrementId)
		{
			var res2 = new salesOrderInfoResponse();
			var cts = new CancellationTokenSource();
			try
			{
				
				//		var sessionId = await this.GetSessionId().ConfigureAwait( false );
				//return = await this._magentoSoapService.salesOrderInfoAsync(sessionId, incrementId).ConfigureAwait(false);

				await ActionPolicies.GetAsync.Do( async () =>
				{
					await Task.Factory.StartNew( async () =>
					{
						cts.CancelAfter( 60000 );

						var sessionId = await this.GetSessionId().ConfigureAwait( false );

						var res = await this._magentoSoapService.salesOrderInfoAsync( sessionId, incrementId ).ConfigureAwait( false );

						res2 = res;
					}, cts.Token ).ConfigureAwait( false );
				}
					).ConfigureAwait( false );

				cts = null;
				return res2;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetOrderAsync(incrementId:{0})", incrementId ), exc );
			}
		}

		public virtual async Task< magentoInfoResponse > GetMagentoInfoAsync()
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var res = await this._magentoSoapService.magentoInfoAsync( sessionId ).ConfigureAwait( false );

				return res;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetMagentoInfoAsync()" ), exc );
			}
		}

		public string ToJsonSoapInfo()
		{
			return string.Format( "{{ApiUser:{0},ApiKey:{1},Store:{2}}}",
				string.IsNullOrWhiteSpace( this.ApiUser ) ? PredefinedValues.NotAvailable : this.ApiUser,
				string.IsNullOrWhiteSpace( this.ApiKey ) ? PredefinedValues.NotAvailable : this.ApiKey,
				string.IsNullOrWhiteSpace( this.Store ) ? PredefinedValues.NotAvailable : this.Store
				);
		}

		#region JustForTesting
		public async Task< int > CreateCart( string storeid )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var res = await this._magentoSoapService.shoppingCartCreateAsync( sessionId, storeid ).ConfigureAwait( false );

				return res.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetMagentoInfoAsync({0})", storeid ), exc );
			}
		}

		public async Task< string > CreateOrder( int shoppingcartid, string store )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var res = await this._magentoSoapService.shoppingCartOrderAsync( sessionId, shoppingcartid, store, null ).ConfigureAwait( false );

				return res.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetMagentoInfoAsync()" ), exc );
			}
		}

		public async Task< int > CreateCustomer(
			string email = "na@na.com",
			string firstname = "firstname",
			string lastname = "lastname",
			string password = "password",
			int website_id = 0,
			int store_id = 0,
			int group_id = 0
			)
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var customerCustomerEntityToCreate = new customerCustomerEntityToCreate()
				{
					email = email,
					firstname = firstname,
					lastname = lastname,
					password = password,
					website_id = website_id,
					store_id = store_id,
					group_id = group_id
				};
				var res = await this._magentoSoapService.customerCustomerCreateAsync( sessionId, customerCustomerEntityToCreate ).ConfigureAwait( false );

				return res.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetMagentoInfoAsync()" ), exc );
			}
		}

		public async Task< bool > ShoppingCartCustomerSet( int shoppingCart, int customerId, string customerPass, string store )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var cutomers = await this._magentoSoapService.customerCustomerListAsync( sessionId, new filters() ).ConfigureAwait( false );

				var customer = cutomers.result.First( x => x.customer_id == customerId );

				var customerShoppingCart = new shoppingCartCustomerEntity()
				{
					confirmation = ( customer.confirmation ? 1 : 0 ).ToString(),
					customer_id = customer.customer_id,
					customer_idSpecified = customer.customer_idSpecified,
					email = customer.email,
					firstname = customer.firstname,
					group_id = customer.group_id,
					group_idSpecified = customer.group_idSpecified,
					lastname = customer.lastname,
					mode = "customer",
					password = customerPass,
					store_id = customer.store_id,
					store_idSpecified = customer.store_idSpecified,
					website_id = customer.website_id,
					website_idSpecified = customer.website_idSpecified
				};
				var res = await this._magentoSoapService.shoppingCartCustomerSetAsync( sessionId, shoppingCart, customerShoppingCart, store ).ConfigureAwait( false );

				return res.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetMagentoInfoAsync()" ), exc );
			}
		}

		public async Task< bool > ShoppingCartGuestCustomerSet( int shoppingCart, string customerfirstname, string customerMail, string customerlastname, string store )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var customer = new shoppingCartCustomerEntity()
				{
					email = customerMail,
					firstname = customerfirstname,
					lastname = customerlastname,
					website_id = 0,
					store_id = 0,
					mode = "guest",
				};

				var res = await this._magentoSoapService.shoppingCartCustomerSetAsync( sessionId, shoppingCart, customer, store ).ConfigureAwait( false );

				return res.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetMagentoInfoAsync()" ), exc );
			}
		}

		public async Task< bool > ShoppingCartAddressSet( int shoppingCart, string store )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var customerAddressEntities = new shoppingCartCustomerAddressEntity[ 2 ];

				customerAddressEntities[ 0 ] = new shoppingCartCustomerAddressEntity()
				{
					mode = "shipping",
					firstname = "testFirstname",
					lastname = "testLastname",
					company = "testCompany",
					street = "testStreet",
					city = "testCity",
					region = "testRegion",
					postcode = "testPostcode",
					country_id = "1",
					telephone = "0123456789",
					fax = "0123456789",
					is_default_shipping = 0,
					is_default_billing = 0
				};
				customerAddressEntities[ 1 ] = new shoppingCartCustomerAddressEntity()
				{
					mode = "billing",
					firstname = "testFirstname",
					lastname = "testLastname",
					company = "testCompany",
					street = "testStreet",
					city = "testCity",
					region = "testRegion",
					postcode = "testPostcode",
					country_id = "1",
					telephone = "0123456789",
					fax = "0123456789",
					is_default_shipping = 0,
					is_default_billing = 0
				};

				var res = await this._magentoSoapService.shoppingCartCustomerAddressesAsync( sessionId, shoppingCart, customerAddressEntities, store ).ConfigureAwait( false );

				return res.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during GetMagentoInfoAsync()" ), exc );
			}
		}

		public async Task< bool > DeleteCustomer( int customerId )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var res = await this._magentoSoapService.customerCustomerDeleteAsync( sessionId, customerId ).ConfigureAwait( false );

				return res.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during DeleteCustomer()" ), exc );
			}
		}

		public async Task< bool > ShoppingCartAddProduct( int shoppingCartId, string productId, string store )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var shoppingCartProductEntities = new shoppingCartProductEntity[ 1 ];

				shoppingCartProductEntities[ 0 ] = new shoppingCartProductEntity() { product_id = productId, qty = 3 };

				var res = await this._magentoSoapService.shoppingCartProductAddAsync( sessionId, shoppingCartId, shoppingCartProductEntities, store ).ConfigureAwait( false );

				return res.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during ShoppingCartAddProduct()" ), exc );
			}
		}

		public async Task< bool > ShoppingCartSetPaymentMethod( int shoppingCartId, string store )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				//var payments = await this._magentoSoapService.shoppingCartPaymentListAsync(sessionId, shoppingCartId, store).ConfigureAwait(false);

				var cartPaymentMethodEntity = new shoppingCartPaymentMethodEntity()
				{
					po_number = null,
					//method = "checkmo",
					method = "checkmo",
					//method = "'cashondelivery'",
					cc_cid = null,
					cc_owner = null,
					cc_number = null,
					cc_type = null,
					cc_exp_year = null,
					cc_exp_month = null
				};

				var res = await this._magentoSoapService.shoppingCartPaymentMethodAsync( sessionId, shoppingCartId, cartPaymentMethodEntity, store ).ConfigureAwait( false );

				return res.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during ShoppingCartAddProduct()" ), exc );
			}
		}

		public async Task< bool > ShoppingCartSetShippingMethod( int shoppingCartId, string store )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var res = await this._magentoSoapService.shoppingCartShippingListAsync( sessionId, shoppingCartId, store ).ConfigureAwait( false );

				var shippings = res.result;
				var shipping = shippings.First();

				var shippingMethodResponse = await this._magentoSoapService.shoppingCartShippingMethodAsync( sessionId, shoppingCartId, shipping.code, store ).ConfigureAwait( false );

				return shippingMethodResponse.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during ShoppingCartAddProduct()" ), exc );
			}
		}
		#endregion

		public async Task< int > CreateProduct( string storeId, string name, string sku, int isInStock )
		{
			try
			{
				var sessionId = await this.GetSessionId().ConfigureAwait( false );

				var catalogProductCreateEntity = new catalogProductCreateEntity()
				{
					name = name,
					description = "Product description",
					short_description = "Product short description",
					weight = "10",
					status = "1",
					visibility = "4",
					price = "100",
					tax_class_id = "1",
					stock_data = new catalogInventoryStockItemUpdateEntity() { qty = "100", is_in_stockSpecified = true, is_in_stock = isInStock, manage_stock = 1, use_config_manage_stock = 0, use_config_min_qty = 0, use_config_min_sale_qty = 0, is_qty_decimal = 0 }
				};
				//var attributes = await this._magentoSoapService.catalogProductAttributeSetListAsync(sessionId).ConfigureAwait(false);

				//var res = await this._magentoSoapService.catalogProductCreateAsync(sessionId, "simple", attributes.result.First().set_id.ToString(),"TddTestSku"+DateTime.UtcNow.Ticks.ToString(), catalogProductCreateEntity,"0").ConfigureAwait(false);

				var res = await this._magentoSoapService.catalogProductCreateAsync( sessionId, "simple", "4", sku, catalogProductCreateEntity, storeId ).ConfigureAwait( false );

				//product id
				return res.result;
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( string.Format( "An error occured during CreateProduct({0})", storeId ), exc );
			}
		}
	}

	internal class PutStockItem
	{
		public PutStockItem( string id, catalogInventoryStockItemUpdateEntity updateEntity )
		{
			this.Id = id;
			this.UpdateEntity = updateEntity;
		}

		public catalogInventoryStockItemUpdateEntity UpdateEntity { get; set; }

		public string Id { get; set; }
	}
}