namespace Genbox.HttpBuilders.Enums;

/// <summary>Most commonly used character sets. See https://w3techs.com/technologies/overview/character_encoding/all You should always be using UTF-8.</summary>
public enum Charset
{
    Unknown = 0,

    /// <summary>zh_HK, zh_MO, zh_TW</summary>
    Big5,
    Euc_jp,
    Euc_kr,

    /// <summary>zh_CN, zh_SG</summary>
    Gb2312,
    Gb18030,

    /// <summary>zh_CN, zh_SG</summary>
    Gbk,
    Iso_2022_jp,

    /// <summary>
    /// af_ZA, arn_CL, ca_ES, cy_GB, da_DK, de_AT, de_CH, de_DE, de_LI, de_LU, en_AU, en_BZ, en_CA, en_CB, en_GB, en_IE, en_JM, en_NZ, en_PH, en_TT,
    /// en_US, en_ZA, en_ZW, es_AR, es_BO, es_CL, es_CO, es_CR, es_DO, es_EC, es_ES, es_GT, es_HN, es_MX, es_NI, es_PA, es_PE, es_PR, es_PY, es_SV, es_UY,
    /// es_VE, eu_ES, fi_FI, fil_PH, fo_FO, fr_BE, fr_CA, fr_CH, fr_FR, fr_LU, fr_MC, fy_NL, ga_IE, gl_ES, id_ID, is_IS, it_CH, it_IT, iu_CA, iv_IV, lb_LU,
    /// moh_CA, ms_BN, ms_MY, nb_NO, nl_BE, nl_NL, nn_NO, ns_ZA, pt_BR, pt_PT, qu_BO, qu_EC, qu_PE, rm_CH, se_FI, se_NO, se_SE, sv_FI, sv_SE, sw_KE, tn_ZA,
    /// xh_ZA, zu_ZA
    /// </summary>
    Iso_8859_1,
    Iso_8859_2,
    Iso_8859_3,
    Iso_8859_4,
    Iso_8859_5,
    Iso_8859_6,
    Iso_8859_7,
    Iso_8859_8,

    /// <summary>az_AZ, tr_TR, uz_UZ</summary>
    Iso_8859_9,
    Iso_8859_10,

    /// <summary>th_TH</summary>
    Iso_8859_11,
    Iso_8859_15,

    /// <summary>ja_JP</summary>
    Shift_jis,

    /// <summary>th_TH</summary>
    Tis_620,
    Utf_7,
    Utf_8,
    Utf_16,
    Utf_16be,
    Utf_16le,
    Utf_32,
    Windows_874,

    /// <summary>ko_KR</summary>
    Windows_949,

    /// <summary>bs_BA, cs_CZ, hr_BA, hr_HR, hu_HU, pl_PL, ro_RO, sk_SK, sl_SI, sq_AL, sr_BA, sr_SP</summary>
    Windows_1250,

    /// <summary>az_AZ, be_BY, bg_BG, kk_KZ, ky_KG, mk_MK, mn_MN, ru_RU, sr_BA, sr_SP, tt_RU, uk_UA, uz_UZ</summary>
    Windows_1251,

    /// <summary>
    /// af_ZA, arn_CL, ca_ES, cy_GB, da_DK, de_AT, de_CH, de_DE, de_LI, de_LU, en_AU, en_BZ, en_CA, en_CB, en_GB, en_IE, en_JM, en_NZ, en_PH, en_TT,
    /// en_US, en_ZA, en_ZW, es_AR, es_BO, es_CL, es_CO, es_CR, es_DO, es_EC, es_ES, es_GT, es_HN, es_MX, es_NI, es_PA, es_PE, es_PR, es_PY, es_SV, es_UY,
    /// es_VE, eu_ES, fi_FI, fil_PH, fo_FO, fr_BE, fr_CA, fr_CH, fr_FR, fr_LU, fr_MC, fy_NL, ga_IE, gl_ES, id_ID, is_IS, it_CH, it_IT, iu_CA, iv_IV, lb_LU,
    /// moh_CA, ms_BN, ms_MY, nb_NO, nl_BE, nl_NL, nn_NO, ns_ZA, pt_BR, pt_PT, qu_BO, qu_EC, qu_PE, rm_CH, se_FI, se_NO, se_SE, sv_FI, sv_SE, sw_KE, tn_ZA,
    /// xh_ZA, zu_ZA
    /// </summary>
    Windows_1252,

    /// <summary>el_GR</summary>
    Windows_1253,

    /// <summary>az_AZ, tr_TR, uz_UZ</summary>
    Windows_1254,

    /// <summary>he_IL</summary>
    Windows_1255,

    /// <summary>ar_AE, ar_BH, ar_DZ, ar_EG, ar_IQ, ar_JO, ar_KW, ar_LB, ar_LY, ar_MA, ar_OM, ar_QA, ar_SA, ar_SY, ar_TN, ar_YE, fa_IR, ps_AF, ur_PK</summary>
    Windows_1256,

    /// <summary>et_EE, lt_LT, lv_LV</summary>
    Windows_1257,

    /// <summary>vi_VN</summary>
    Windows_1258
}