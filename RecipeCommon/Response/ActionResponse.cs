using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCommon.Response
{
     public class ActionResponse
        {
            public bool IsSucceed { get; set; }
            public string[] FailureResult { get; set; }


            public static ActionResponse Failure(params string[] failureResult)
            {
                var actionResult = new ActionResponse();
                Failure(actionResult, failureResult);
                return actionResult;
            }

            public static ActionResponse Succeed()
            {
                var actionResult = new ActionResponse();
                Succeed(actionResult);
                return actionResult;
            }

            protected static void Failure(ActionResponse result, params string[] failureResult)
            {
                Contract.Requires(failureResult != null);
                Contract.Requires(failureResult.Any());
                result.IsSucceed = false;
                result.FailureResult = failureResult;
            }

            protected static void Succeed(ActionResponse result)
            {
                result.IsSucceed = true;
                result.FailureResult = new string[0];
            }



        }
        public class ActionResponse<T> : ActionResponse
        {
            public T Data { get; set; }

            public new static ActionResponse<T> Failure(params string[] failureResult)
            {
                var response = new ActionResponse<T>();
                Failure(response, failureResult);
                return response;
            }

            public static ActionResponse<T> Succeed(T data)
            {
                var response = new ActionResponse<T>() { Data = data };
                Succeed(data);
                return response;
            }




        }
}
