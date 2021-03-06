using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Elasticsearch.Net.Integration.Yaml.IndicesValidateQuery1
{
	public partial class IndicesValidateQuery1YamlTests
	{	


		[NCrunch.Framework.ExclusivelyUses("ElasticsearchYamlTests")]
		public class ValidateQueryApi1Tests : YamlTestsBase
		{
			[Test]
			public void ValidateQueryApi1Test()
			{	

				//do indices.create 
				this.Do(()=> _client.IndicesCreate("testing", null));

				//do cluster.health 
				this.Do(()=> _client.ClusterHealth(nv=>nv
					.Add("wait_for_status", @"yellow")
				));

				//do indices.validate_query 
				this.Do(()=> _client.IndicesValidateQueryGetForAll(nv=>nv
					.Add("q", @"query string")
				));

				//is_true _response.valid; 
				this.IsTrue(_response.valid);

				//do indices.validate_query 
				_body = new {
					query= new {
						invalid_query= new {}
					}
				};
				this.Do(()=> _client.IndicesValidateQueryForAll(_body));

				//is_false _response.valid; 
				this.IsFalse(_response.valid);

			}
		}
	}
}

