using IPE.SmsIrRestful.TPL.NetCore;
using KishApp.SMSIR.UltraFastSMS;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.DependencyInjection;

namespace KishApp.SMSIR
{
	public class UltraFastSMSService : ITransientDependency
	{
		public UltraFastSMSService()
		{

		}
		public UltraFastSMSResult Send(UltraFastSMSInput input)
		{
			if (string.IsNullOrWhiteSpace(input.Mobile)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "To");
			if (input.Parameters == null || input.Parameters.Count() == 0) throw new ArgumentException("Value cannot be NULL .", "Parameters");

			var Params = new List<UltraFastParameters>();

			foreach (var item in input.Parameters)
			{
				Params.Add(new UltraFastParameters { Parameter = item.Key, ParameterValue = item.Value });
			}
			var ultraFastSend = new UltraFastSend()
			{
				Mobile = Int64.Parse(input.Mobile),
				TemplateId = input.TemplateId,
				ParameterArray = Params.ToArray()
			};
			var Token = new Token().GetToken(input.ApiKey, input.SecretKey);
			UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(Token, ultraFastSend);

			UltraFastSMSResult result = new UltraFastSMSResult
			{
				IsSuccessful = ultraFastSendRespone.IsSuccessful,
				Message = ultraFastSendRespone.Message,
				VerificationCodeId = ultraFastSendRespone.VerificationCodeId
			};
			return result;
		}
	}
}
