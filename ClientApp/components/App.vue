<template>
    <div class="app">
        <b-navbar toggleable="md" type="dark" variant="dark">
            <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
            <b-navbar-brand to="/">Phone Shop</b-navbar-brand>
            <b-collapse is-nav id="nav_collapse">
                <b-navbar-nav>
                    <b-nav-item to="/products">Products</b-nav-item>
                    <b-nav-item v-if="isAdmin" to="/admin">Admin</b-nav-item>
                </b-navbar-nav>
                
                <b-navbar-nav class="ml-auto mr-4">
                    <cart-summary v-if="isCustomer" />
                    <auth-nav-item />
                </b-navbar-nav>
            </b-collapse>
        </b-navbar>

        <transition name="fade" mode="out-in">
            <router-view />
        </transition>

        <auth-modal :show="showAuthModal" />
    </div>

</template>

<script>
    import CartSummary from "./cart/CartSummary.vue";
    import AuthNavItem from "./app/AuthNavItem.vue";
    import AuthModal from "./app/AuthModal.vue";

    export default {
        name: "app",
        components: {
            CartSummary,
            AuthNavItem,
            AuthModal
        },
        beforeCreate() {
            // moved to boot.js so that it runs in the correct order (before authoriation navigation guard)
            // this.$store.commit("initialize");
        },
        computed: {
            showAuthModal() {
                return this.$store.state.showAuthModal;
            },
            isCustomer() {
                return (
                    this.$store.getters.isInRole("Customer") || !this.$store.isAuthenticated
                );
            },
            isAdmin() {
                return this.$store.getters.isInRole("Admin");
            }
        }
    };
    
</script>


<style lang="scss">
html,
body {
  height: 100vh;
}

h1 {
    font-size: 1.8rem;
}

h2 {
    font-size: 1.5rem;
}

h3 {
    font-size: 1.25rem;
}

h4 {
    font-size: 1.15rem;
}

div {
    &.app,
    &.pageZZZ {
        height: 100% !important;
    }
}

#nprogress {
    .spinner {
        left: 0;
        right: 0;
        margin-top: 4.5rem;
    }

    .spinner-icon {
        margin: 0 auto;
    }
}

.fade-enter-active,
.fade-leave-active {
    transition: opacity 0.05s ease-in-out;
}

.fade-enter,
.fade-leave-to {
    opacity: 0;
}
</style>

