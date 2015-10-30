using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<MissingAggregation>))]
	public interface IMissingAggregation : IBucketAggregation
	{
		[JsonProperty("field")]
		FieldName Field { get; set; }
	}

	public class MissingAggregation : BucketAggregation, IMissingAggregation
	{
		public FieldName Field { get; set; }

		public MissingAggregation(string name) : base(name) { }

		internal override void WrapInContainer(AggregationContainer c) => c.Missing = this;
	}

	public class MissingAggregationDescriptor<T> 
		: BucketAggregationDescriptorBase<MissingAggregationDescriptor<T>,IMissingAggregation, T>
			, IMissingAggregation 
		where T : class
	{
		FieldName IMissingAggregation.Field { get; set; }

		public MissingAggregationDescriptor<T> Field(string field) => Assign(a => a.Field = field);

		public MissingAggregationDescriptor<T> Field(Expression<Func<T, object>> field) => Assign(a => a.Field = field);

	}
}