using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts
{
    public enum EnumPrivacy
    {
        [Description("Özel")]
        Private = 1,
        [Description("Genel")]
        Public = 2

    }

    public enum EnumTaskTypes
    {


        [Description("insan kaynakları")]
        InsanKaynaklari = 4,
        [Description("Bilgi Talebi")]
        BilgiNotu = 20, [Description("Personel Talebi")]
        PersonelTalebi = 22,
        [Description("Temenni")]
        Temenni = 29,
        [Description("Öneri/İstek/Şikayet")]
        OneriIstekSikayet = 30,
        [Description("Faaliyet Raporu")]
        FaaliyetRaporu = 31,
        [Description("Toplantı")]
        Toplanti = 32,
        [Description("Mailler")]
        Mailler = 33

    }

    public enum EnumTaskState
    {
        Iptal = 0,
        YeniKayit = 1,
        Bekliyor = 2,
        Islemde = 3,
        Tamamlandi = 4
      
       

    }

    public enum EnumTaskGroup
    {
        Draft = 0,
        Income = 1,
        Sent = 2
  
    }



    public enum EnumTaskViewState
    {

        Görülmedi,
        Görüldü,
    }

    public enum EnumUserGroup
    {
        Admin=1,
        OzelKalemCalisani = 2,
        Kullanici = 3

    }
}
