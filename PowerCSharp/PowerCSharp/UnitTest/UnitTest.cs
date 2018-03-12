using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.UnitTest
{
    class UnitTest
    {
        ////[Ignore]
        //[TestClass]
        //public class DxdDal_ProbeDbReplLatency_Test
        //{
        //    DxRpdtdbaGetReplLatencyRequest LatRequest;
        //    DxdDalProbeDbReplLatency_ParamModel param;
        //    DxTdalsysGetDalApiDbSwitchConfigResponseModelItem switchConfigItem;
        //    DxRpdtdbaGetReplLatencyResponseModel latRecords;
        //    DxRpdtdbaGetReplLatencyResponseModel latRecords2;


        //    [TestInitialize]
        //    public void TestInit()
        //    {

        //        LatRequest = new DxRpdtdbaGetReplLatencyRequest()
        //        {
        //            Data = new DxRpdtdbaGetReplLatencyRequestModel()
        //            {
        //                Location = "TPE",
        //                Publications = new List<string>() { "McnClient_attend_list", "McnMemberClassRecord", "McnClientAttendListDetail", "McnClassrecordExtend", "McnCommon_s", "McnLobby", "McnMaterial_change_history", "JRLession", "JRcfg" },
        //                PublisherCommitStart = Convert.ToDateTime("2017-11-28 17:47:51.42"),
        //                PublisherCommitEnd = Convert.ToDateTime("2017-11-28 17:50:51.42")
        //            }
        //        };

        //        param = new DxdDalProbeDbReplLatency_ParamModel()
        //        {
        //            DbLocation = "TPE",
        //            NotifyTutorChatStaffSn = 16456
        //        };

        //        switchConfigItem = new DxTdalsysGetDalApiDbSwitchConfigResponseModelItem()
        //        {
        //            Service = "InformationApi",
        //            DalApiSolution = "Dx.InformationServiceNode",
        //            DbLocation = "TPE",
        //            LuaDbNameMaster = "master",
        //            LuaDbNameRepl = "TPEREPL2",
        //            LatencyLevel = 1,
        //            LevelName = "Low Latency",
        //            SwitchThreshMs = 6000,
        //            SampleRangeSec = 180,
        //            SampleRatePerc = 100,
        //            Publications = new List<string>() { "McnClient_attend_list", "McnMemberClassRecord", "McnClientAttendListDetail", "McnClassrecordExtend", "McnCommon_s", "McnLobby", "McnMaterial_change_history", "JRLession", "JRcfg" }
        //        };

        //        latRecords2 = new DxRpdtdbaGetReplLatencyResponseModel()
        //        {
        //            Items = new List<DxRpdtdbaGetReplLatencyResponseModelItem>() 
        //        {
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:01.42"),LatTotal=6666},
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:11.42"),LatTotal=7777},
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:21.42"),LatTotal=8888},
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:31.42"),LatTotal=9999},            
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:41.42"),LatTotal=8888},   
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:51.42"),LatTotal=7777},   
        //        }
        //        };

        //        latRecords = new DxRpdtdbaGetReplLatencyResponseModel()
        //        {
        //            Items = new List<DxRpdtdbaGetReplLatencyResponseModelItem>() 
        //        {
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:01.42"),LatTotal=3333},
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:11.42"),LatTotal=4444},
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:21.42"),LatTotal=5555},
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:31.42"),LatTotal=6666},            
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:41.42"),LatTotal=4444},   
        //            new DxRpdtdbaGetReplLatencyResponseModelItem(){publication="McnClient_attend_list",PublisherCommit=Convert.ToDateTime("2017-11-28 17:47:51.42"),LatTotal=3333},   
        //        }
        //        };

        //    }

        //    #region ProbeDbReplLatency
        //    //[TestMethod, TestCategory("DxdDal")]
        //    //public void DxdDal_ProbeDbReplLatency_Single_Test_ReturnCountMany()
        //    //{
        //    //    var service = DxdAllAsmEnvDataServiceLocator.Get<IDxdDalProbeDbReplLatency_DataService>();
        //    //    var request = new DxdDalProbeDbReplLatency_ParamModel()
        //    //    {

        //    //    };
        //    //    var result = service.ProbeDbReplLatency_Single(request);

        //    //    Assert.IsNotNull(result);
        //    //}
        //    #endregion

        //    #region DetermineSwitchDb 沒有延遲
        //    [TestMethod, TestCategory("DxdDal")]
        //    public void DxdDal_DetermineSwitchDb_Test_ReturnString()
        //    {
        //        // 只有一筆超過閥值

        //        // 都先改為分流機DB
        //        ResetDevTpeDbSwitchMemCached();

        //        var service = DxdAllAsmEnvDataServiceLocator.Get<IDxdDalProbeDbReplLatency_DataService>();

        //        // test private method
        //        PrivateObject po = new PrivateObject(service);

        //        var result = po.Invoke("DetermineSwitchDb",
        //            latRecords,
        //            switchConfigItem,
        //            param,
        //            LatRequest);


        //        //Assert.IsNotNull(result);
        //        Assert.AreEqual("MemCached上面的DB切換設定檔，不需要變更", result, "不相等，Unit test沒有通過");
        //        //Assert.AreEqual("找不到可以變更的DB切換設定檔，新增一筆DB切換設定檔到MemCached", result);

        //        // 結束後再改回分流機DB
        //        ResetDevTpeDbSwitchMemCached();
        //    }
        //    #endregion

        //    #region DetermineSwitchDb 延遲
        //    [TestMethod, TestCategory("DxdDal")]
        //    public void DxdDal_DetermineSwitchDb_Test_ReturnString_Latency()
        //    {
        //        // 全部延遲紀錄都超過閥值

        //        // 都先改為分流機DB
        //        ResetDevTpeDbSwitchMemCached();

        //        var service = DxdAllAsmEnvDataServiceLocator.Get<IDxdDalProbeDbReplLatency_DataService>();

        //        // test private method
        //        PrivateObject po = new PrivateObject(service);

        //        var result = po.Invoke("DetermineSwitchDb",
        //            latRecords2,
        //            switchConfigItem,
        //            param,
        //            LatRequest);

        //        //Assert.IsNotNull(result);
        //        Assert.AreEqual("結果:[DAL API DB智能切換][DEV][偵測到DB複寫延遲] 已將 Dx.InformationServiceNode 切換到主DB<br>參數:<br>DalApiSolution-Location-Evn-DB-IsRep is Dx.InformationServiceNode-TPE-DEV-master-False <br> 延遲閥值SwitchThreshMs=6000 秒<br> 延遲紀錄筆數=6 <br> 大於SwitchThreshMs筆數=6 <br>", result, "不相等，Unit test沒有通過");

        //        // 結束後再改回分流機DB
        //        ResetDevTpeDbSwitchMemCached();
        //    }
        //    #endregion

        //    private void ResetDevTpeDbSwitchMemCached()
        //    {
        //        var model = new DxConnSwitchCachedClient.DbConnSwitch()
        //        {
        //            Env = "DEV",
        //            DalData = "Dx.InformationServiceNode",
        //            Location = "TPE",
        //            DbName = "TPEREPL2",
        //            IsReplicaTime = true
        //        };

        //        var items = DxConnSwitchCachedClient.Get();
        //        var target = items.FirstOrDefault
        //            (w =>
        //                w.DalData == model.DalData
        //                && w.Location == model.Location
        //                && w.Env == model.Env);

        //        if (target != null)
        //        {
        //            DxConnSwitchCachedClient.UpdateByDalDataLocEnv(model);
        //        }
        //        else
        //        {
        //            model.Id = Guid.NewGuid();
        //            items.Add(model);
        //            DxConnSwitchCachedClient.Set(items);
        //        }

        //        var model2 = new DxConnSwitchCachedClient.DbConnSwitch()
        //        {
        //            Env = "DEV",
        //            DalData = "Dx.MuchnewdbServiceNode",
        //            Location = "TPE",
        //            DbName = "TPEREPL2",
        //            IsReplicaTime = true
        //        };

        //        var items2 = DxConnSwitchCachedClient.Get();
        //        var target2 = items2.FirstOrDefault
        //            (w =>
        //               w.DalData == model2.DalData
        //                && w.Location == model2.Location
        //                && w.Env == model2.Env);

        //        if (target2 != null)
        //        {
        //            DxConnSwitchCachedClient.UpdateByDalDataLocEnv(model2);
        //        }
        //        else
        //        {
        //            model2.Id = Guid.NewGuid();
        //            items2.Add(model2);
        //            DxConnSwitchCachedClient.Set(items2);
        //        }

        //    }

        //}

    }
}
