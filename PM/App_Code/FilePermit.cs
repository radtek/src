namespace cn.justwin.stockModel
{
    using System;

    [Serializable]
    public class FilePermit
    {
        private string _pcode;
        private string _ptype;
        private string _tcode;
        private string _tpid;
        private string _pread;
        private string _pwrite;
        

        public string pcode
        {
            get
            {
                return this._pcode;
            }
            set
            {
                this._pcode = value;
            }
        }

        public string ptype
        {
            get
            {
                return this._ptype;
            }
            set
            {
                this._ptype = value;
            }
        }

        public string tcode
        {
            get
            {
                return this._tcode;
            }
            set
            {
                this._tcode = value;
            }
        }

        public string tpid
        {
            get
            {
                return this._tpid;
            }
            set
            {
                this._tpid = value;
            }
        }
        public string pread
        {
            get
            {
                return this._pread;
            }
            set
            {
                this._pread = value;
            }
        }
        public string pwrite
        {
            get
            {
                return this._pwrite;
            }
            set
            {
                this._pwrite = value;
            }
        }
    }
}

