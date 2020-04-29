using Anadolu.BusinessLayer.Results;
using Anadolu.Entitiess;
using Anadolu.Entitiess.Messages;
using Anadolu.Entitiess.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anadolu.BusinessLayer
{
  public  class AdminManager:ManagerBase<Admin>
    {

        //public BusinessLayerResult<Admin> RegisterUser(RegisterViewModel data)
        //{
        //    // Kullanıcı username kontrolü..
        //    // Kullanıcı e-posta kontrolü..
        //    // Kayıt işlemi..
        //    // Aktivasyon e-postası gönderimi.
        //    Admin user = Find(x => x.NickName == data.Username || x.AdminEmail == data.EMail);
        //    BusinessLayerResult<Admin> res = new BusinessLayerResult<Admin>();

        //    if (user != null)
        //    {
        //        if (user.AdminEmail == data.Username)
        //        {
        //            res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
        //        }

        //        if (user.AdminEmail == data.EMail)
        //        {
        //            res.AddError(ErrorMessageCode.EmailAlreadyExists, "E-posta adresi kayıtlı.");
        //        }
        //    }
        //    else
        //    {
        //        int dbResult = base.Insert(new Admin()
        //        {
        //            Username = data.Username,
        //            Email = data.EMail,
        //            ProfileImageFilename = "user_boy.png",
        //            Password = data.Password,
        //            ActivateGuid = Guid.NewGuid(),
        //            IsActive = false,
        //            IsAdmin = false
        //        });

        //        if (dbResult > 0)
        //        {
        //            res.Result = Find(x => x.Email == data.EMail && x.Username == data.Username);

        //            string siteUri = ConfigHelper.Get<string>("SiteRootUri");
        //            string activateUri = $"{siteUri}/Home/UserActivate/{res.Result.ActivateGuid}";
        //            string body = $"Merhaba {res.Result.Username};<br><br>Hesabınızı aktifleştirmek için <a href='{activateUri}' target='_blank'>tıklayınız</a>.";

        //            MailHelper.SendMail(body, res.Result.Email, "MyEvernote Hesap Aktifleştirme");
        //        }
        //    }

        //    return res;
        //}

        //public BusinessLayerResult<EvernoteUser> GetUserById(int id)
        //{
        //    BusinessLayerResult<EvernoteUser> res = new BusinessLayerResult<EvernoteUser>();
        //    res.Result = Find(x => x.Id == id);

        //    if (res.Result == null)
        //    {
        //        res.AddError(ErrorMessageCode.UserNotFound, "Kullanıcı bulunamadı.");
        //    }

        //    return res;
        //}

        public BusinessLayerResult<Admin> LoginUser(LoginViewModel data)
        {
            // Giriş kontrolü
            // Hesap aktive edilmiş mi?
            BusinessLayerResult<Admin> res = new BusinessLayerResult<Admin>();
            res.Result = Find(x => x.AdminEmail == data.Username && x.Password == data.Password);

            if (res.Result != null)
            {
                //if (!res.Result.IsActive)
                //{
                //    res.AddError(ErrorMessageCode.UserIsNotActive, "Kullanıcı aktifleştirilmemiştir.");
                //    res.AddError(ErrorMessageCode.CheckYourEmail, "Lütfen e-posta adresinizi kontrol ediniz.");
                //}
                data.Aktif = true;
            }
            else
            {
                res.AddError(ErrorMessageCode.UsernameOrPassWrong, "Kullanıcı adı yada şifre uyuşmuyor.");
            }

            return res;
        }

    //    public BusinessLayerResult<EvernoteUser> UpdateProfile(EvernoteUser data)
    //    {
    //        EvernoteUser db_user = Find(x => x.Id != data.Id && (x.Username == data.Username || x.Email == data.Email));
    //        BusinessLayerResult<EvernoteUser> res = new BusinessLayerResult<EvernoteUser>();

    //        if (db_user != null && db_user.Id != data.Id)
    //        {
    //            if (db_user.Username == data.Username)
    //            {
    //                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
    //            }

    //            if (db_user.Email == data.Email)
    //            {
    //                res.AddError(ErrorMessageCode.EmailAlreadyExists, "E-posta adresi kayıtlı.");
    //            }

    //            return res;
    //        }

    //        res.Result = Find(x => x.Id == data.Id);
    //        res.Result.Email = data.Email;
    //        res.Result.Name = data.Name;
    //        res.Result.Surname = data.Surname;
    //        res.Result.Password = data.Password;
    //        res.Result.Username = data.Username;

    //        if (string.IsNullOrEmpty(data.ProfileImageFilename) == false)
    //        {
    //            res.Result.ProfileImageFilename = data.ProfileImageFilename;
    //        }

    //        if (base.Update(res.Result) == 0)
    //        {
    //            res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Profil güncellenemedi.");
    //        }

    //        return res;
    //    }

    //    public BusinessLayerResult<EvernoteUser> RemoveUserById(int id)
    //    {
    //        BusinessLayerResult<EvernoteUser> res = new BusinessLayerResult<EvernoteUser>();
    //        EvernoteUser user = Find(x => x.Id == id);

    //        if (user != null)
    //        {
    //            if (Delete(user) == 0)
    //            {
    //                res.AddError(ErrorMessageCode.UserCouldNotRemove, "Kullanıcı silinemedi.");
    //                return res;
    //            }
    //        }
    //        else
    //        {
    //            res.AddError(ErrorMessageCode.UserCouldNotFind, "Kullanıcı bulunamadı.");
    //        }

    //        return res;
    //    }

    //    public BusinessLayerResult<EvernoteUser> ActivateUser(Guid activateId)
    //    {
    //        BusinessLayerResult<EvernoteUser> res = new BusinessLayerResult<EvernoteUser>();
    //        res.Result = Find(x => x.ActivateGuid == activateId);

    //        if (res.Result != null)
    //        {
    //            if (res.Result.IsActive)
    //            {
    //                res.AddError(ErrorMessageCode.UserAlreadyActive, "Kullanıcı zaten aktif edilmiştir.");
    //                return res;
    //            }

    //            res.Result.IsActive = true;
    //            Update(res.Result);
    //        }
    //        else
    //        {
    //            res.AddError(ErrorMessageCode.ActivateIdDoesNotExists, "Aktifleştirilecek kullanıcı bulunamadı.");
    //        }

    //        return res;
    //    }


    //    // Method hiding..
    //    public new BusinessLayerResult<EvernoteUser> Insert(EvernoteUser data)
    //    {
    //        EvernoteUser user = Find(x => x.Username == data.Username || x.Email == data.Email);
    //        BusinessLayerResult<EvernoteUser> res = new BusinessLayerResult<EvernoteUser>();

    //        res.Result = data;

    //        if (user != null)
    //        {
    //            if (user.Username == data.Username)
    //            {
    //                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
    //            }

    //            if (user.Email == data.Email)
    //            {
    //                res.AddError(ErrorMessageCode.EmailAlreadyExists, "E-posta adresi kayıtlı.");
    //            }
    //        }
    //        else
    //        {
    //            res.Result.ProfileImageFilename = "user_boy.png";
    //            res.Result.ActivateGuid = Guid.NewGuid();

    //            if (base.Insert(res.Result) == 0)
    //            {
    //                res.AddError(ErrorMessageCode.UserCouldNotInserted, "Kullanıcı eklenemedi.");
    //            }
    //        }

    //        return res;
    //    }

    //    public new BusinessLayerResult<EvernoteUser> Update(EvernoteUser data)
    //    {
    //        EvernoteUser db_user = Find(x => x.Username == data.Username || x.Email == data.Email);
    //        BusinessLayerResult<EvernoteUser> res = new BusinessLayerResult<EvernoteUser>();
    //        res.Result = data;

    //        if (db_user != null && db_user.Id != data.Id)
    //        {
    //            if (db_user.Username == data.Username)
    //            {
    //                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
    //            }

    //            if (db_user.Email == data.Email)
    //            {
    //                res.AddError(ErrorMessageCode.EmailAlreadyExists, "E-posta adresi kayıtlı.");
    //            }

    //            return res;
    //        }

    //        res.Result = Find(x => x.Id == data.Id);
    //        res.Result.Email = data.Email;
    //        res.Result.Name = data.Name;
    //        res.Result.Surname = data.Surname;
    //        res.Result.Password = data.Password;
    //        res.Result.Username = data.Username;
    //        res.Result.IsActive = data.IsActive;
    //        res.Result.IsAdmin = data.IsAdmin;

    //        if (base.Update(res.Result) == 0)
    //        {
    //            res.AddError(ErrorMessageCode.UserCouldNotUpdated, "Kullanıcı güncellenemedi.");
    //        }

    //        return res;
    //    }
    //}



}
}
