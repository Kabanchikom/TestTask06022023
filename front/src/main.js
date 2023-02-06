import { createApp } from 'vue'
import App from './App.vue'
import store from "@/store";
import "bootstrap/dist/css/bootstrap.min.css"
import router from "@/router/router";

createApp(App)
    .use(store)
    .use(router)
    .mount('#app');
