using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;


namespace Nest.Tests.Integration.Yaml.Index
{
	public partial class Index55ParentWithRoutingYaml55Tests
	{
		
		public class ParentWithRouting55Tests
		{
			private readonly RawElasticClient _client;
			private object _body;
		
			public ParentWithRouting55Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void ParentWithRoutingTests()
			{

				//do indices.create 
				_body = new {
					mappings= new {
						test= new {
							_parent= new {
								type= "foo"
							}
						}
					},
					settings= new {
						number_of_replicas= "0"
					}
				};
				this._client.IndicesCreatePost("test_1", _body, nv=>nv);

				//do cluster.health 
				
				this._client.ClusterHealthGet(nv=>nv);

				//do index 
				_body = new {
					foo= "bar"
				};
				this._client.IndexPost("test_1", "test", "1", _body, nv=>nv);

				//do get 
				
				this._client.Get("test_1", "test", "1", nv=>nv);

				//do get 
				
				this._client.Get("test_1", "test", "1", nv=>nv);

				//do get 
				
				this._client.Get("test_1", "test", "1", nv=>nv);
			}
		}
	}
}