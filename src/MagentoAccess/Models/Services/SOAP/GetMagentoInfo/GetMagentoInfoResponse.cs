using MagentoAccess.MagentoSoapServiceReference;

namespace MagentoAccess.Models.Services.Soap.GetMagentoInfo
{
	internal class GetMagentoInfoResponse
	{
		public GetMagentoInfoResponse( magentoInfoResponse res )
		{
			this.MagentoEdition = res.result.magento_edition;
			this.MagentoVersion = res.result.magento_version;
		}

		public GetMagentoInfoResponse( MagentoSoapServiceReference_v_1_14_1_EE.magentoInfoResponse res )
		{
			this.MagentoEdition = res.result.magento_edition;
			this.MagentoVersion = res.result.magento_version;
		}

		public GetMagentoInfoResponse( string magentoVersion, string magentoEdition )
		{
			this.MagentoEdition = magentoEdition;
			this.MagentoVersion = magentoVersion;
		}

		public GetMagentoInfoResponse( TsZoey_v_1_9_0_1_CE.magentoInfoResponse res )
		{
			this.MagentoEdition = res.result.magento_edition;
			this.MagentoVersion = res.result.magento_version;
		}

		public string MagentoVersion { get; set; }

		public string MagentoEdition { get; set; }
	}
}