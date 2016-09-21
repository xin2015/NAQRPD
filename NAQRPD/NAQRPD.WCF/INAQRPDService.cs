using NAQRPD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NAQRPD.WCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“INAQRPDService”。
    [ServiceContract]
    public interface INAQRPDService
    {

        [OperationContract]
        List<AQRPD> GetAQRPSDLive();

        [OperationContract]
        List<AQDPD> GetAQSPSDLive();

        [OperationContract]
        List<AQRPD> GetAQRPSDHistory(DateTime beginTime, DateTime endTime);

        [OperationContract]
        List<AQDPD> GetAQDPSDLive();

        [OperationContract]
        List<AQDPD> GetAQDPSDHistory(DateTime beginTime, DateTime endTime);

        [OperationContract]
        List<AQRPD> GetAQRPCDLive();

        [OperationContract]
        List<AQRPD> GetAQRPCDHistory(DateTime beginTime, DateTime endTime);

        [OperationContract]
        List<AQDPD> GetAQDPCDLive();

        [OperationContract]
        List<AQDPD> GetAQDPCDHistory(DateTime beginTime, DateTime endTime);
    }
}
