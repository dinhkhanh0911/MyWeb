
using DatabaseProvider.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    public class DBIO
    {
        MyDatabase myDb = new MyDatabase();

        //Dung chung
        public void addObject<T>(T obj)
        {
            myDb.Set(obj.GetType()).Add(obj);
        }
        public void removeObject<T>(T obj)
        {
            myDb.Set(obj.GetType()).Remove(obj);
        }
        public void save()
        {
            myDb.SaveChanges();
        }

        //user
        public User GetByUserName(string userName)
        {
            //string Sql = "SELECT * FROM user WHERE userName ='" + userName + "' AND userPassword= '" + userPassword + "'";
            //return myDb.Database.SqlQuery<user>(Sql).FirstOrDefault();
            return myDb.Database.SqlQuery<User>(
                    "SELECT * FROM users WHERE userName = @u",
                    new SqlParameter("@u",userName)
                    
                ).FirstOrDefault();
        }
        public User GetByUserID(int idUser)
        {
            //string Sql = "SELECT * FROM user WHERE userName ='" + userName + "' AND userPassword= '" + userPassword + "'";
            //return myDb.Database.SqlQuery<user>(Sql).FirstOrDefault();
            return myDb.Database.SqlQuery<User>(
                    "SELECT * FROM users WHERE idUser = @u",
                    new SqlParameter("@u", idUser)

                ).FirstOrDefault();
        }

        //HocPhan
        public HocPhan getHocPhan(int idHocPhan)
        {
            //string Sql = "SELECT * FROM user WHERE userName ='" + userName + "' AND userPassword= '" + userPassword + "'";
            //return myDb.Database.SqlQuery<user>(Sql).FirstOrDefault();
            return myDb.Database.SqlQuery<HocPhan>(
                    "SELECT * FROM HocPhan WHERE idHocPhan = @h",
                    new SqlParameter("@h", idHocPhan)


                ).FirstOrDefault();
        }

        public List<HocPhan> getListHocPhan()
        {
            //string Sql = "SELECT * FROM user WHERE userName ='" + userName + "' AND userPassword= '" + userPassword + "'";
            //return myDb.Database.SqlQuery<user>(Sql).FirstOrDefault();
            return myDb.Database.SqlQuery<HocPhan>(
                    "SELECT * FROM HocPhan "


                ).ToList();
        }
        
        public List<HocPhan> getListHocPhanbyName(string inputSearch)
        {
            //List<HocPhan> list =(from h in myDb.HocPhans
            //        where h.tenHocPhan == inputSearch
            //        select h).ToList();
            //return list;
            return myDb.Database.SqlQuery<HocPhan>(
                    "SELECT * FROM HocPhan WHERE HocPhan.tenHocPhan = @t",
                    new SqlParameter("@t", inputSearch)


                ).ToList();
        }
        public List<HocPhan> getListHocPhanbyID(int idUser)
        {
            //List<HocPhan> list =(from h in myDb.HocPhans
            //        where h.tenHocPhan == inputSearch
            //        select h).ToList();
            //return list;
           return myDb.Database.SqlQuery<HocPhan>(
                    "SELECT * FROM HocPhan WHERE HocPhan.idUser = @i",
                    new SqlParameter("@i", idUser)


                ).ToList();

            
        }
        public Object getListHocPhanNgoaiTaobyID(int idUser)
        {
            var list = (from h in myDb.HocPhans
                        join d in myDb.HocPhanNgoaiTaos
                         on h.idHocPhan equals d.idHocPhan
                        where d.idUser == 2
                        select new
                        {
                            id = h.idUser,
                            tenHocPhan = h.tenHocPhan,
                            isPrivate = h.isPrivate
                        }).ToList();
            return list;
        }

        public List<TheTu> getListTheTuByTenHocPhan(string tenHocPhan)
        {
            var listTheTu = (from t in myDb.TheTus
                             join h in myDb.HocPhans on t.idHocPHan equals h.idHocPhan
                             where h.tenHocPhan == "Động vật"
                             select t).ToList();
                        
            return listTheTu;
        }
        public bool checkUserName (string userName)
        {

            return myDb.Users.Count(u => u.userName == userName) > 0;
        }
        public bool checkPassword(string Password)
        {

            return myDb.Users.Count(u => u.userPassword == Password) > 0;
        }
        
        public HocPhan createHocPhan(string inputHocPhan,int idUser)
        {
            HocPhan h = new HocPhan();
            h.tenHocPhan = inputHocPhan;
            h.idUser = idUser;
            h.isPrivate = true;
            h.dateCreated = DateTime.Now;
            return h;
        }
        public void addHocPhanNgoaiTao(int idHocPhan,int idUser)
        {
            HocPhanNgoaiTao h = new HocPhanNgoaiTao();
            h.idHocPhan = idHocPhan;
            h.idUser = idUser;
            h.dateOfAdd = DateTime.Now;
            addObject(h);
            save();
        }

        //Truy van lop hoc
        //ThemLopHoc
        public LopHoc createLopHoc(string tenLopHoc, string descriptionClass,int idUser)
        {
            LopHoc l = new LopHoc();
            l.tenLop = tenLopHoc;
            l.descriptionClass = descriptionClass;
            l.idUser = idUser;
            l.dateCreated = DateTime.Now;
            return l;
        }


        //TruyVan
        public object getListLopHoc(int idUser)
        {
            
            return (from l in myDb.LopHocs 
                    where l.idUser == idUser
                    select new
                    {
                        idUser = l.idUser,
                        tenLop = l.tenLop,
                        idLopHoc = l.idLopHoc,
                        descriptionClass = l.descriptionClass,
                        dateCreated = l.dateCreated
                    }).ToList() ;
        }
        public object getListLopHoc(int idUser,string tenLopHoc)
        {

            return (from l in myDb.LopHocs
                    where l.idUser == idUser && l.tenLop==tenLopHoc
                    select new
                    {
                        idUser = l.idUser,
                        tenLop = l.tenLop,
                        idLopHoc = l.idLopHoc,
                        descriptionClass = l.descriptionClass,
                        dateCreated = l.dateCreated
                    }).ToList();
        }
        public object getLopHoc(int idLopHoc)
        {
            return (from l in myDb.LopHocs
                    where l.idLopHoc == idLopHoc
                    select new
                    {
                        idUser = l.idUser,
                        tenLop = l.tenLop,
                        idLopHoc = l.idLopHoc,
                        descriptionClass = l.descriptionClass,
                        dateCreated = l.dateCreated
                    }).FirstOrDefault();
            
        }
        public LopHoc getLopHoc_2(int idLopHoc)
        {
            return myDb.Database.SqlQuery<LopHoc>(
                    "SELECT * FROM LopHoc WHERE LopHoc.idLopHoc = @t",
                    new SqlParameter("@t", idLopHoc)


                ).FirstOrDefault();
        }
        public void removeLopHoc(int idLopHoc,int idUser)
        {
            LopHoc lop = myDb.LopHocs.Where(l => l.idLopHoc == idLopHoc && l.idUser == idUser).FirstOrDefault();
            removeObject(lop);

        }

        //Hoc sinh
        public HocSinh createHocSinh(int idUser,int idLop)
        {
            HocSinh h = new HocSinh();
            h.idUser = idUser;
            h.idLopHoc = idLop;
            h.dateOfJoin = DateTime.Now;

            return h;

        }
        
        public object getListHocSinh(int idLop)
        {
            var listHocSinh = myDb.HocSinhs.Where(h => h.idLopHoc == idLop);
            var list = (from u in myDb.Users join lh in listHocSinh on u.idUser equals lh.idUser
                        select new {
                            idUser = u.idUser,
                            fullName = u.fullName
                        });
            return list;
        }
        public bool checkHocsinh(int idUser,int idLopHoc)
        {
            return myDb.HocSinhs.Count(h => h.idUser == idUser && h.idLopHoc == idLopHoc ) > 0;
        }

        //The Tu
        public object getListTheTu(int idHocPhan)
        {
            var list = (from l in myDb.TheTus where l.idHocPHan == idHocPhan
                        select new
                        {
                            idTheTu = l.idTheTu,
                            idHocPhan = l.idHocPHan,
                            engWord = l.engWord,
                            viWord = l.viWord,
                            images = l.images,
                            example = l.example
                        }
                        ).ToList() ;
            return list;
        }
        public void addTheTu(string engWord,string viWord,int idHocPhan)
        {
            TheTu t = new TheTu();
            t.idHocPHan = idHocPhan;
            t.engWord = engWord;
            t.viWord = viWord;
            addObject(t);

        }
        public void editTheTu(string engWord, string viWord, int idTheTu)
        {
            TheTu t = myDb.TheTus.Where(tt => tt.idTheTu == idTheTu).FirstOrDefault();

            t.engWord = engWord;
            t.viWord = viWord;
        }
        public void deleteTheTu(int idTheTu)
        {
            TheTu t = myDb.TheTus.Where(tt => tt.idTheTu == idTheTu).FirstOrDefault();

            removeObject(t);
        }
    }
}
