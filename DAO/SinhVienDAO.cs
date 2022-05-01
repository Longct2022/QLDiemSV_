﻿using QLDiemSV.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSV.DAO
{

    public class SinhVienDAO
    {
        DataHelper dh;
        DataTable dt;
        public SinhVienDAO(string sqlcon)
        {
            dh = new DataHelper(sqlcon);
        }
        public List<SinhVien> LayDSSinhVien()
        {
            List<SinhVien> lsv = new List<SinhVien>();
            dt =  dh.FillDataTable("select * from SINH_VIEN");
            foreach (DataRow dr in dt.Rows)
            {          
                lsv.Add(new SinhVien
                {
                    MaSV = dr["MaSV"].ToString(),
                    HoTen = dr["HoTen"].ToString(),
                    DiaChi = dr["DiaChi"].ToString(),
                    MaLop = dr["MaLop"].ToString(),
                    GioiTinh = dr["GioiTinh"].ToString(),
                    NgaySinh = dr["NgaySinh"].ToString()
                });    
            }    
            return lsv;
        }

        public void ThemSV(SinhVien sv)
        {
            dh.AddRow(dt, sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.DiaChi, sv.MaLop);
            dh.UpdateDataTableToDatabase(dt, "SINH_VIEN");
        }
        public void XoaSV(string maSV)
        {
            dh.DeleteRows(dt, "MaSV = '" + maSV + "'");
            dh.UpdateDataTableToDatabase(dt, "SINH_VIEN");
        }
        public void SuaSV(SinhVien sv)
        {
            dh.EditRow(dt, "MaSV = '" + sv.MaSV + "'", sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.DiaChi, sv.MaLop);
            dh.UpdateDataTableToDatabase(dt, "SINH_VIEN");
        }
    }


}
