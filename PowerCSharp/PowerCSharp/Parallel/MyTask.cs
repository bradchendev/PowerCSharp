using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.Parallel
{
    class MyTask
    {
        /// <summary>
        /// 以工作為基礎的非同步程式設計
        /// https://docs.microsoft.com/zh-tw/dotnet/standard/parallel-programming/task-based-asynchronous-programming
        /// </summary>
        void testc()
        {
            // columbia
            //var request = new DxCbaGetStaffBasicRequest
            //{
            //    Data = param.ConvertTo<DxCbaGetStaffBasicRequestModel>()
            //};

            //var response = new DxCbaGetStaffBasicResponse();
            ////response = ColumbiaServiceClient.Invoke(request, Dxd.Dealer.Contract.ServiceConfig.HostDx_Columbia);

            //Task taskA = new Task(() =>
            //{
            //    response = ColumbiaServiceClient.Invoke(request, Dxd.Dealer.Contract.ServiceConfig.HostDx_Columbia);
            //});

            //// Define and run the task.
            ////Task taskA = Task.Run(() =>
            ////{
            ////    response = ColumbiaServiceClient.Invoke(request, Dxd.Dealer.Contract.ServiceConfig.HostDx_Columbia);
            ////});

            //// muchnewdb
            //var requestMcn = new DxMcnGetStaffBasicRequest
            //{
            //    Data = param.ConvertTo<DxMcnGetStaffBasicRequestModel>()
            //};

            //var responseMcn = new DxMcnGetStaffBasicResponse();

            ////Task taskB = Task.Run(() =>
            ////{
            ////    responseMcn = MuchnewdbServiceClient.Invoke(requestMcn, Dxd.Dealer.Contract.ServiceConfig.HostDx_Muchnewdb);
            ////});
            //Task taskB = new Task(() =>
            //{
            //    responseMcn = MuchnewdbServiceClient.Invoke(requestMcn, Dxd.Dealer.Contract.ServiceConfig.HostDx_Muchnewdb);
            //});

            //Task[] taskArray = new Task[2] { taskA, taskB };
            //Parallel.ForEach(taskArray, task => task.Start());
            //Task.WaitAll(taskArray);  

        }
    }
}
