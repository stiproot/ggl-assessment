namespace Ggl.Slst.Db.Consts;

internal static class StoredProcs
{
    public const string UpsertLst = "fn_upsert_lst";
    public const string GetLst = "fn_get_lst";
    public const string DeleteLst = "fn_delete_lst";

    public const string UpsertUsr = "fn_upsert_usr";
    public const string GetUsr = "fn_get_usr";
    public const string DeleteUsr = "fn_delete_usr";

    public const string UpsertImg = "fn_upsert_img";
    public const string GetImg = "fn_get_img";
    public const string DeleteImg = "fn_delete_img";

    public const string UpsertProduct = "fn_upsert_product";
    public const string GetProduct = "fn_get_product";
    public const string DeleteProduct = "fn_delete_product";

    public const string InsertProductImgMapping = "fn_insert_product_img_mapping";
    public const string GetProductImgMapping = "fn_get_product_img_mapping";
    public const string DeleteProductImgMapping = "fn_delete_product_img_mapping";

    public const string UpsertExtAccessToken = "fn_upsert_ext_access_token";
    public const string GetExtAccessToken = "fn_get_ext_access_token";
    public const string DeleteExtAccessToken = "fn_delete_ext_access_token";
}