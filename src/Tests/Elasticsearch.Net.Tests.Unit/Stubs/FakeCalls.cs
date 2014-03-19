using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.FakeItEasy;
using Elasticsearch.Net.Connection;
using Elasticsearch.Net.Providers;
using FakeItEasy;
using FakeItEasy.Configuration;

namespace Elasticsearch.Net.Tests.Unit.Stubs
{
	public static class FakeCalls 
	{
		public static IReturnValueConfiguration<ElasticsearchResponse<DynamicDictionary>> GetSyncCall(AutoFake fake)
		{
			return A.CallTo(() =>
				fake.Resolve<IConnection>().GetSync<DynamicDictionary>(A<Uri>._, null));
		}
		public static IReturnValueArgumentValidationConfiguration<Task<ElasticsearchResponse<DynamicDictionary>>> GetCall(AutoFake fake)
		{
			return A.CallTo(() => 
				fake.Resolve<IConnection>().Get<DynamicDictionary>(A<Uri>._, A<object>._));
		}

		public static IReturnValueArgumentValidationConfiguration<bool> Ping(AutoFake fake)
		{
			return A.CallTo(() => fake.Resolve<IConnection>().Ping(A<Uri>._));
		}

		public static ITransport ProvideDefaultTransport(AutoFake fake)
		{
			var param = new TypedParameter(typeof(IDateTimeProvider), null);
			return fake.Provide<ITransport, Transport>(param);
		}

	}
}