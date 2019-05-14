<template>
    <!-- <div>
        <h1>Welcome to Hands on Vue.js with ASP.NET Core!</h1>
        <p>
            The time is now: {{ time }}
        </p>
        
        <p>The current users of our system are:</p>
        <ul>
            <li v-for="user in users" :key="user.userName">
                {{ user.fullName }} - {{ user.userName }}
            </li>
        </ul>
        <product-list />
    </div> -->
<div class="app">
    <b-navbar toggleable="md" type="dark" variant="dark">
        <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
        <b-navbar-brand to="/">Phone Shop</b-navbar-brand>
        <b-collapse is-nav id="nav_collapse">
            <b-navbar-nav>
                <b-nav-item to="/products">Products</b-nav-item>
            </b-navbar-nav>
        </b-collapse>
    </b-navbar>

    <transition name="fade" mode="out-in">
        <router-view />
    </transition>
</div>

</template>

<script>
export default {
    name: "app",
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
    &.page {
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
    transition: opacity 0.2s ease-in-out;
}

.fade-enter,
.fade-leave-to {
    opacity: 0;
}
</style>

