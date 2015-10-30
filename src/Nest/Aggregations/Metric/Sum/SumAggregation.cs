﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<SumAggregation>))]
	public interface ISumAggregation : IMetricAggregation { }

	public class SumAggregation : MetricAggregation, ISumAggregation
	{
		public SumAggregation(string name, FieldName field) : base(name, field) { }

		internal override void WrapInContainer(AggregationContainer c) => c.Sum = this;
	}

	public class SumAggregationDescriptor<T> 
		: MetricAggregationDescriptorBase<SumAggregationDescriptor<T>, ISumAggregation, T>
			, ISumAggregation 
		where T : class { }
}
