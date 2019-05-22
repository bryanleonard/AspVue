import Vue from 'vue';
import VueRouter from 'vue-router';
import store from "./store";
import BootstrapVue from "bootstrap-vue";
import NProgress from "nprogress";
import VueToastr from "@deveodk/vue-toastr";
import "@deveodk/vue-toastr/dist/@deveodk/vue-toastr.css";
import axios from "axios";
import VeeValidate from "vee-validate";

Vue.use(VueRouter);
Vue.use(BootstrapVue);
Vue.use(VueToastr, {
    defaultPosition: "toast-top-center"
});
Vue.use(VeeValidate);

// filters
import { currency, date } from "./filters";
Vue.filter("currency", currency);
Vue.filter("date", date);

//import page components
import Catalog from "./pages/Catalog.vue";
import Product from "./pages/Product.vue";
import Cart from    "./pages/Cart.vue";
import Checkout from    "./pages/Checkout.vue";
import Account from    "./pages/Account.vue";
// import { Verify } from 'crypto';

const initialStore = localStorage.getItem("store");

if (initialStore){
    store.commit("initialize", JSON.parse(initialStore));

    if (store.getters.isAuthenticated){
        axios.defaults.headers.common["Authorization"] = `Bearer ${store.state.auth.access_token}`;
    }
}

const routes = [
    { path: "/products", component: Catalog },
    { path: "/products/:slug", component: Product },
    { path: "/cart", component: Cart },
    { path: "/checkout", component: Checkout,   meta: { requiresAuth: true } },
    { path: "/account", component: Account,     meta: { requiresAuth: true } },
    { path: "*", redirect: "/products" }
];

const router = new VueRouter({mode: "history", routes: routes});

router.beforeEach((to, from , next) => {
    NProgress.start();
    if (to.matched.some(route => route.meta.requiresAuth)) { //Array.some similar to LINQ Any
        if (!store.getters.isAuthenticated) {
            store.commit("showAuthModal");
            next({ path: from.path, query: { redirect: to.path } });
        }
        else {
            next();
        }
    } else {
        next();
    }
});

// eslint-disable-next-line no-unused-vars
router.afterEach((to, from) => {
    NProgress.done();
});

new Vue({
    el: '#app-root',
    // before NProgress
    //router: new VueRouter({ mode: 'history', routes: routes }),
    router: router,
    store,
    // eslint-disable-next-line no-undef
    render: h => h(require('./components/App.vue'))
});
