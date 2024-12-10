namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Helpers
{
    public class Helpers
    {
        private static List<string> urlImages = ["https://res.cloudinary.com/dh6brjozr/image/upload/v1733814379/z6115963889168_b97899a39ea27808b877598468f50f2e_av9fbt.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814379/z6115963889143_db9f5ead72ba1945a634739dd7a8f56d_lupnfw.jpg",
        "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814379/z6115963853313_664844d36bfdd34e55183796825e6a7d_ietxww.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814378/z6115963853284_66977ee003ad63d4f68ec828ebe7207b_mc6vgx.jpg",
        "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814378/z6115963853113_515b1bf868c22b149d5516ae926b2931_exbjza.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814378/z6115963833597_03433bd72098d36aefc0323e0cf17573_olptwp.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814378/z6115963833597_03433bd72098d36aefc0323e0cf17573_olptwp.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814378/z6115963833430_b2b877bac0abdbdc27926defcae43511_kdyji0.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814378/z6115963812878_a54f2e0b1f9f9d2b7067c29c667b0099_nw3eby.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814377/z6115963812839_0475f7abd7dc22a88e3d0a722c2e5de3_xficow.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814377/z6115963812838_54640d229463c7ff6346bd66171405fb_f2oecv.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814377/z6115963793638_564c759c0015c2e6984aa8b9336e16d2_zwk9gm.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814377/z6115963793638_564c759c0015c2e6984aa8b9336e16d2_zwk9gm.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814377/z6115963793636_339af4965e71e0f79d19ba9666dd72db_qtme8u.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814376/z6115963775375_f9af71f3cab9347e4a18ed3ab524fee6_u0xuho.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814376/z6115963775368_f8771f2887566cca21b4daf5e99f5ee6_gfkveq.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814376/z6115963756977_62672c44934d116c9073709b9c5c3079_joodah.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814376/z6115963756955_4155df74bb394bdf63293337e2dcfbe0_sr0lbe.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814376/z6115963756955_4155df74bb394bdf63293337e2dcfbe0_sr0lbe.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814376/z6115963740449_8a5690d362ef64b92f6b59a1b20a69a5_nnbeoz.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814375/z6115963740431_5cf17a9da33aff1866acd8e95a28dd58_n17kz3.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814375/z6115963740429_3a627471a3868d306cc04aad4d531941_qcrmdb.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814375/z6115963740427_e74e432b428bdfc40baa15f32f2c4a5e_j9bl3h.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814375/z6115963720050_8f266f824c425be64e8f311d6c36c177_iibp9l.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814375/z6115963720041_2f6bd3ebb8d4d238febe0b2a5c1102b3_qwpnd7.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814375/z6115963720040_251b1aa91b60b0385e9e04bd34e6fb41_ds2nnk.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814374/z6115963700320_6de2efab309ae238645ba65f6849fa4c_wyfgvv.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814374/z6115963700320_6de2efab309ae238645ba65f6849fa4c_wyfgvv.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814374/z6115963681666_9b1f1e94e600b7d080ddcde48add2cb9_vre8xn.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814374/z6115963681650_6a1dd4d0531de704674ad5bc05a897c0_mifvld.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814374/z6115963660824_11c5f03123fd41acbc8bf716f21e76b1_l5jrhq.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814374/z6115963660805_e1276408d16c29156e3409e6c52502b6_oyczmz.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814373/z6115963660804_3736e11e7fa7673e98568bb38ee443c8_cpwwr2.jpg",
            "https://res.cloudinary.com/dh6brjozr/image/upload/v1733814339/z6115963660686_ee9ae5a3d3fe3b41832a5e70a5e099a0_dxchj2.jpg"
        ];
        public static string randomDefaultAvatar()
        {
            Random random = new Random();
            int randomIndex = random.Next(urlImages.Count);
            return urlImages[randomIndex];
        }
    }
}
