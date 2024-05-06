
using Journy.Model.features;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Journy.Model
{
    public class JourneyContext : DbContext
    {
        public JourneyContext(DbContextOptions<JourneyContext> options) : base(options)
        { }

        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Pin> Pins { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Country> Countries { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserAccount>().HasIndex(r => r.Email).IsUnique();
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Afghanistan", Id = 2 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Åland Islands", Id = 3 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Albania", Id = 4 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Algeria", Id = 5 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "American Samoa", Id = 6 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Andorra", Id = 7 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Angola", Id = 8 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Anguilla", Id = 9 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Antarctica", Id = 10 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Antigua & Barbuda", Id = 11 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Argentina", Id = 12 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Armenia", Id = 13 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Aruba", Id = 14 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Australia", Id = 15 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Austria", Id = 16 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Azerbaijan", Id = 17 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Bahamas", Id = 18 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Bahrain", Id = 19 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Bangladesh", Id = 20 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Barbados", Id = 21 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Belarus", Id = 22 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Belgium", Id = 23 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Belize", Id = 24 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Benin", Id = 25 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Bermuda", Id = 26 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Bhutan", Id = 27 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Bolivia", Id = 28 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Bosnia & Herzegovina", Id = 29 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Botswana", Id = 30 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Bouvet Island", Id = 31 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Brazil", Id = 32 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "British Indian Ocean Territory", Id = 33 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "British Virgin Islands", Id = 34 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Brunei", Id = 35 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Bulgaria", Id = 36 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Burkina Faso", Id = 37 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Burundi", Id = 38 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Cambodia", Id = 39 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Cameroon", Id = 40 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Canada", Id = 41 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Cape Verde", Id = 42 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Caribbean Netherlands", Id = 43 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Cayman Islands", Id = 44 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Central African Republic", Id = 45 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Chad", Id = 46 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Chile", Id = 47 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "China", Id = 48 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Christmas Island", Id = 49 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Cocos(Keeling) Islands", Id = 50 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Colombia", Id = 51 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Comoros", Id = 52 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Congo - Brazzaville", Id = 53 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Congo - Kinshasa", Id = 54 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Cook Islands", Id = 55 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Costa Rica", Id = 56 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Côte d’Ivoire", Id = 57 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Croatia", Id = 58 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Cuba", Id = 59 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Curaçao", Id = 60 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Cyprus", Id = 61 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Czechia", Id = 62 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Denmark", Id = 63 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Djibouti", Id = 64 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Dominica", Id = 65 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Dominican Republic", Id = 66 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Ecuador", Id = 67 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Egypt", Id = 68 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "El Salvador", Id = 69 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Equatorial Guinea", Id = 70 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Eritrea", Id = 71 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Estonia", Id = 72 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Eswatini", Id = 73 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Ethiopia", Id = 74 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Falkland Islands", Id = 75 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Faroe Islands", Id = 76 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Fiji", Id = 77 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Finland", Id = 78 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "France", Id = 79 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "French Guiana", Id = 80 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "French Polynesia", Id = 81 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "French Southern Territories", Id = 82 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Gabon", Id = 83 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Gambia", Id = 84 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Georgia", Id = 85 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Germany", Id = 86 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Ghana", Id = 87 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Gibraltar", Id = 88 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Greece", Id = 89 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Greenland", Id = 90 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Grenada", Id = 91 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Guadeloupe", Id = 92 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Guam", Id = 93 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Guatemala", Id = 94 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Guernsey", Id = 95 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Guinea", Id = 96 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Guinea-Bissau", Id = 97 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Guyana", Id = 98 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Haiti", Id = 99 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Heard & McDonald Islands", Id = 100 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Honduras", Id = 101 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Hong Kong SAR China", Id = 102 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Hungary", Id = 103 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Iceland", Id = 104 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "India", Id = 105 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Indonesia", Id = 106 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Iran", Id = 107 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Iraq", Id = 108 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Ireland", Id = 109 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Isle of Man", Id = 110 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Italy", Id = 112 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Jamaica", Id = 113 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Japan", Id = 114 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Jersey", Id = 115 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Jordan", Id = 116 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Kazakhstan", Id = 117 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Kenya", Id = 118 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Kiribati", Id = 119 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Kuwait", Id = 120 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Kyrgyzstan", Id = 121 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Laos", Id = 122 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Latvia", Id = 123 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Lebanon", Id = 124 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Lesotho", Id = 125 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Liberia", Id = 126 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Libya", Id = 127 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Liechtenstein", Id = 128 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Lithuania", Id = 129 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Luxembourg", Id = 130 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Macao SAR China", Id = 131 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Madagascar", Id = 132 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Malawi", Id = 133 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Malaysia", Id = 134 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Maldives", Id = 135 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Mali", Id = 136 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Malta", Id = 137 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Marshall Islands", Id = 138 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Martinique", Id = 139 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Mauritania", Id = 140 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Mauritius", Id = 141 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Mayotte", Id = 142 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Mexico", Id = 143 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Micronesia", Id = 144 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Moldova", Id = 145 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Monaco", Id = 146 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Mongolia", Id = 147 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Montenegro", Id = 148 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Montserrat", Id = 149 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Morocco", Id = 150 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Mozambique", Id = 151 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Myanmar(Burma)", Id = 152 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Namibia", Id = 153 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Nauru", Id = 154 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Nepal", Id = 155 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Netherlands", Id = 156 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "New Caledonia", Id = 157 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "New Zealand", Id = 158 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Nicaragua", Id = 159 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Niger", Id = 160 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Nigeria", Id = 161 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Niue", Id = 162 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Norfolk Island", Id = 163 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "North Korea", Id = 164 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "North Macedonia", Id = 165 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Northern Mariana Islands", Id = 166 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Norway", Id = 167 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Oman", Id = 168 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Pakistan", Id = 169 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Palau", Id = 170 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Palestinian Territories", Id = 171 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Panama", Id = 172 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Papua New Guinea", Id = 173 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Paraguay", Id = 174 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Peru", Id = 175 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Philippines", Id = 176 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Pitcairn Islands", Id = 177 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Poland", Id = 178 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Portugal", Id = 179 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Puerto Rico", Id = 180 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Qatar", Id = 181 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Réunion", Id = 182 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Romania", Id = 183 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Russia", Id = 184 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Rwanda", Id = 185 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Samoa", Id = 186 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "San Marino", Id = 187 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "São Tomé & Príncipe", Id = 188 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Saudi Arabia", Id = 189 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Senegal", Id = 190 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Serbia", Id = 191 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Seychelles", Id = 192 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Sierra Leone", Id = 193 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Singapore", Id = 194 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Sint Maarten", Id = 195 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Slovakia", Id = 196 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Slovenia", Id = 197 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Solomon Islands", Id = 198 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Somalia", Id = 199 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "South Africa", Id = 200 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "South Georgia & South Sandwich Islands", Id = 201 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "South Korea", Id = 202 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "South Sudan", Id = 203 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Spain", Id = 204 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Sri Lanka", Id = 205 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "St.Barthélemy", Id = 206 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "St.Helena", Id = 207 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "St.Kitts & Nevis", Id = 208 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "St.Lucia", Id = 209 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "St.Martin", Id = 210 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "St.Pierre & Miquelon", Id = 211 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "St.Vincent & Grenadines", Id = 212 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Sudan", Id = 213 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Suriname", Id = 214 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Svalbard & Jan Mayen", Id = 215 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Sweden", Id = 216 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Switzerland", Id = 217 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Syria", Id = 218 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Taiwan", Id = 219 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Tajikistan", Id = 220 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Tanzania", Id = 221 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Thailand", Id = 222 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Timor-Leste", Id = 223 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Togo", Id = 224 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Tokelau", Id = 225 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Tonga", Id = 226 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Trinidad & Tobago", Id = 227 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Tunisia", Id = 228 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Turkey", Id = 229 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Turkmenistan", Id = 230 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Turks & Caicos Islands", Id = 231 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Tuvalu", Id = 232 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "U.S.Outlying Islands", Id = 233 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "U.S.Virgin Islands", Id = 234 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Uganda", Id = 235 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Ukraine", Id = 236 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "United Arab Emirates", Id = 237 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "United Kingdom", Id = 238 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "United States", Id = 239 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Uruguay", Id = 240 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Uzbekistan", Id = 241 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Vanuatu", Id = 242 });
            modelBuilder.Entity<Country>().HasData(new Country
            {
                CountryName = "Vatican City" , Id = 243 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Venezuela", Id = 244 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Vietnam", Id = 245 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Wallis & Futuna", Id = 246 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Western Sahara", Id = 247 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Yemen", Id = 248 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Zambia", Id = 249 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Zimbabwe", Id = 250 });
        }
    }


}
