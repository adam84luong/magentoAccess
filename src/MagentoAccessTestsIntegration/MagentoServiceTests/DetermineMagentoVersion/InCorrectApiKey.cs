using System;
using System.Linq;
using FluentAssertions;
using MagentoAccess;
using MagentoAccessTestsIntegration.TestEnvironment;
using NUnit.Framework;

namespace MagentoAccessTestsIntegration.MagentoServiceTests.DetermineMagentoVersion
{
	[ TestFixture ]
	[ Category( "ReadSmokeTests" ) ]
	[ Parallelizable ]
	internal class InCorrectApiKey : BaseTest
	{
		[ Test ]
		[ TestCaseSource( typeof( GeneralTestCases ), "TestStoresCredentials" ) ]
		public void ReceiveNull( MagentoServiceCredentialsAndConfig credentials )
		{
			// ------------ Arrange
			var magentoService = this.CreateMagentoService( credentials.AuthenticatedUserCredentials.SoapApiUser, credentials.AuthenticatedUserCredentials.SoapApiKey + "_incorrectKey", "null", "null", "null", "null", credentials.AuthenticatedUserCredentials.SoapApiKey, "http://w.com", "http://w.com", "http://w.com", credentials.Config.VersionByDefault, credentials.AuthenticatedUserCredentials.GetProductsThreadsLimit, credentials.AuthenticatedUserCredentials.SessionLifeTimeMs, true, credentials.Config.UseVersionByDefaultOnly, ThrowExceptionIfFailed.AllItems );

			// ------------ Act
			var getOrdersTask = magentoService.DetermineMagentoVersionAsync();
			getOrdersTask.Wait();

			// ------------ Assert
			var pingSoapInfo = getOrdersTask.Result;

			pingSoapInfo.Any( x => x.SoapWorks && string.Compare( x.Version, credentials.Config.VersionByDefault, StringComparison.CurrentCultureIgnoreCase ) == 0 ).Should().BeFalse();
		}
	}
}