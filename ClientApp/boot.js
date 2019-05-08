import Vue from 'vue';
import VueRouter from 'vue-router';
import BootstrapVue from "bootstrap-vue";

Vue.use(VueRouter);
Vue.use(BootstrapVue);

import Catalog from "./pages/Catalog.vue";
import Product from "./pages/Product.vue";
import { Verify } from 'crypto';

const routes = [
    { path: "/products", component: Catalog },
    { path: "/products/:slug", component: Product },
    { path: "*", redirect: "/products" }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/App.vue'))
});
