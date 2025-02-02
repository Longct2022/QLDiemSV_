﻿using QLDiemSV.DAO;
using QLDiemSV.Entities;
using System.Collections.Generic;

namespace QLDiemSV.BUS
{
    public class QLSinhVienBUS
    {
        DataHelper dh;
        SinhVienDAO svDAO = new SinhVienDAO(Program.strcon);
        LopDAO lopDAO = new LopDAO(Program.strcon);
        public QLSinhVienBUS(string strcon)
        {
            dh = new DataHelper(strcon);
        }

        public List<SinhVien> LayDSSinhVien()
        {
            return svDAO.LayDSSinhVien();
        }
        public List<SinhVien> LayDSSinhVien(string maLop)
        {
            return svDAO.LayDSSinhVien(maLop);
        }
        public List<Lop> LayDSLop()
        {
            return lopDAO.LayDSLop();
        }
        public void ThemSV(SinhVien sv)
        {
            svDAO.ThemSV(sv);
            lopDAO.SuaSiSo(1, sv.MaLop);
        }
        public void XoaSV(SinhVien sv)
        {
            svDAO.XoaSV(sv.MaSV);
            lopDAO.SuaSiSo(-1, sv.MaLop);
        }
        public void SuaSV(SinhVien sv)
        {
            svDAO.SuaSV(sv);
            lopDAO.SuaSiSo(-1, sv.MaLop);
        }
        public void SuaSV(SinhVien sv, string maLopHienTai)
        {
            svDAO.SuaSV(sv);
            lopDAO.SuaSiSo(-1, sv.MaLop, maLopHienTai);
        }

    }
}
