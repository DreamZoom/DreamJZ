using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.Shop
{
    public class good_service : EntityServiceBase<goods>
    {
        public string GenericShopNo()
        {
            return string.Format("{0}-{1}", Guid.NewGuid().ToString(), DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff"));
        }

        public override bool Create(goods entity)
        {
            entity.good_no = GenericShopNo();
            return base.Create(entity);
        }
    }
}
