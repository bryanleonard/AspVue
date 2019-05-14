import Vue from 'vue';
import VueRouter from 'vue-router';
import store from "./store";
import BootstrapVue from "bootstrap-vue";
import NProgress from "nprogress";

Vue.use(VueRouter);
Vue.use(BootstrapVue);

import Catalog from "./pages/Catalog.vue";
import Product from "./pages/Product.vue";
import Cart from "./pages/Cart.vue";
import { Verify } from 'crypto';

const routes = [
    { path: "/products", component: Catalog },
    { path: "/products/:slug", component: Product },
    { path: "/cart", component: Cart },
    { path: "*", redirect: "/products" }
];

const router = new VueRouter({mode: "history", routes: routes});
router.beforeEach((to, from , next) => {
    NProgress.start();
    next();
});

router.afterEach((to, from) => {
    NProgress.done();
});

new Vue({
    el: '#app-root',
    // before NProgress
    //router: new VueRouter({ mode: 'history', routes: routes }),
    router: router,
    store,
    render: h => h(require('./components/App.vue'))
});
