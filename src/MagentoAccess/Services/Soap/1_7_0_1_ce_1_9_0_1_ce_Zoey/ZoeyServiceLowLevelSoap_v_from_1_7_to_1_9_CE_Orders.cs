﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using MagentoAccess.MagentoSoapServiceReference;
using MagentoAccess.Misc;
using MagentoAccess.Models.Services.Soap.GetOrders;
using Netco.Logging;

namespace MagentoAccess.Services.Soap._1_7_0_1_ce_1_9_0_1_ce_Zoey
{
	internal partial class ZoeyServiceLowLevelSoap_v_from_1_7_to_1_9_CE : IMagentoServiceLowLevelSoap
	{
		public virtual async Task< GetOrdersResponse > GetOrdersAsync( DateTime modifiedFrom, DateTime modifiedTo, Mark mark = null )
		{
			try
			{
				TsZoey_v_1_9_0_1_CE.filters filters;

				if( string.IsNullOrWhiteSpace( this.Store ) )
					filters = new TsZoey_v_1_9_0_1_CE.filters { complex_filter = new TsZoey_v_1_9_0_1_CE.complexFilter[ 2 ] };
				else
				{
					filters = new TsZoey_v_1_9_0_1_CE.filters { complex_filter = new TsZoey_v_1_9_0_1_CE.complexFilter[ 3 ] };
					filters.complex_filter[ 2 ] = new TsZoey_v_1_9_0_1_CE.complexFilter { key = "store_id", value = new TsZoey_v_1_9_0_1_CE.associativeEntity { key = "in", value = this.Store } };
				}

				filters.complex_filter[ 1 ] = new TsZoey_v_1_9_0_1_CE.complexFilter { key = "updated_at", value = new TsZoey_v_1_9_0_1_CE.associativeEntity { key = "from", value = modifiedFrom.ToSoapParameterString() } };
				filters.complex_filter[ 0 ] = new TsZoey_v_1_9_0_1_CE.complexFilter { key = "updated_at", value = new TsZoey_v_1_9_0_1_CE.associativeEntity { key = "to", value = modifiedTo.ToSoapParameterString() } };

				const int maxCheckCount = 2;
				const int delayBeforeCheck = 1800000;

				var res = new TsZoey_v_1_9_0_1_CE.salesOrderListResponse();

				var privateClient = this._clientFactory.GetClient();


				await ActionPolicies.GetAsync.Do( async () =>
				{
					var statusChecker = new StatusChecker( maxCheckCount );
					TimerCallback tcb = statusChecker.CheckStatus;

					privateClient = this._clientFactory.RefreshClient( privateClient );
					var sessionId = await this.GetSessionId().ConfigureAwait( false );

					using( var stateTimer = new Timer( tcb, privateClient, 1000, delayBeforeCheck ) )
						res = await privateClient.salesOrderListAsync( sessionId.SessionId, filters ).ConfigureAwait( false );
				} ).ConfigureAwait( false );

				//crutch for magento 1.7 
				res.result = res.result.Where( x => Extensions.ToDateTimeOrDefault( x.updated_at ) >= modifiedFrom && Extensions.ToDateTimeOrDefault( x.updated_at ) <= modifiedTo ).ToArray();

				return new GetOrdersResponse( res );
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( $"An error occured during GetOrdersAsync(modifiedFrom:{modifiedFrom},modifiedTo{modifiedTo})", exc );
			}
		}

		public virtual async Task< GetOrdersResponse > GetOrdersAsync( IEnumerable< string > ordersIds )
		{
			var ordersIdsAgregated = string.Empty;
			try
			{
				ordersIdsAgregated = string.Join( ",", ordersIds );

				TsZoey_v_1_9_0_1_CE.filters filters;
				if( string.IsNullOrWhiteSpace( this.Store ) )
					filters = new TsZoey_v_1_9_0_1_CE.filters { complex_filter = new TsZoey_v_1_9_0_1_CE.complexFilter[ 1 ] };
				else
				{
					filters = new TsZoey_v_1_9_0_1_CE.filters { complex_filter = new TsZoey_v_1_9_0_1_CE.complexFilter[ 2 ] };
					filters.complex_filter[ 1 ] = new TsZoey_v_1_9_0_1_CE.complexFilter { key = "store_id", value = new TsZoey_v_1_9_0_1_CE.associativeEntity { key = "in", value = this.Store } };
				}

				filters.complex_filter[ 0 ] = new TsZoey_v_1_9_0_1_CE.complexFilter { key = "increment_id", value = new TsZoey_v_1_9_0_1_CE.associativeEntity { key = "in", value = ordersIdsAgregated } };

				const int maxCheckCount = 2;
				const int delayBeforeCheck = 1800000;

				var res = new TsZoey_v_1_9_0_1_CE.salesOrderListResponse();

				var privateClient = this._clientFactory.GetClient();


				await ActionPolicies.GetAsync.Do( async () =>
				{
					var statusChecker = new StatusChecker( maxCheckCount );
					TimerCallback tcb = statusChecker.CheckStatus;

					privateClient = this._clientFactory.RefreshClient( privateClient );
					var sessionId = await this.GetSessionId().ConfigureAwait( false );

					using( var stateTimer = new Timer( tcb, privateClient, 1000, delayBeforeCheck ) )
						res = await privateClient.salesOrderListAsync( sessionId.SessionId, filters ).ConfigureAwait( false );
				} ).ConfigureAwait( false );

				return new GetOrdersResponse( res );
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( $"An error occured during GetOrdersAsync({ordersIdsAgregated})", exc );
			}
		}

		public virtual async Task< OrderInfoResponse > GetOrderAsync( string incrementId, Mark childMark )
		{
			try
			{
				const int maxCheckCount = 2;
				const int delayBeforeCheck = 300000;

				var res = new TsZoey_v_1_9_0_1_CE.salesOrderInfoResponse();

				var privateClient = this._clientFactory.GetClient();

				await ActionPolicies.GetAsync.Do( async () =>
				{
					var statusChecker = new StatusChecker( maxCheckCount );
					TimerCallback tcb = statusChecker.CheckStatus;

					privateClient = this._clientFactory.RefreshClient( privateClient );
					var sessionId = await this.GetSessionId().ConfigureAwait( false );

					using( var stateTimer = new Timer( tcb, privateClient, 1000, delayBeforeCheck ) )
						res = await privateClient.salesOrderInfoAsync( sessionId.SessionId, incrementId ).ConfigureAwait( false );
				} ).ConfigureAwait( false );

				return new OrderInfoResponse( res );
			}
			catch( Exception exc )
			{
				throw new MagentoSoapException( $"An error occured during GetOrderAsync(incrementId:{incrementId})", exc );
			}
		}

		public virtual Task< OrderInfoResponse > GetOrderAsync( Order order, Mark childMark )
		{
			return this.GetOrderAsync( this.GetOrdersUsesEntityInsteadOfIncrementId ? order.OrderId : order.incrementId, childMark );
		}
	}
}