/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Views/**/*.cshtml',
    './wwwroot/**/*.html',
        './wwwroot/**/*.js',
        "./node_modules/flowbite/**/*.js",
        flowbite.content(),
  ],
  theme: {
    extend: {},
  },
    plugins: [
        require('flowbite/plugin')({
            datatables: true,
            charts: true,
        }),
        flowbite.plugin(),
        // ... other plugins
    ],
}
